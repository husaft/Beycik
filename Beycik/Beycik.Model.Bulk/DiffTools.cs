using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Beycik.Model.Roots;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Beycik.Model.Bulk
{
    public static class DiffTools
    {
        public static XmlDocument LoadXml(string file)
        {
            var doc = new XmlDocument();
            doc.Load(file);
            return doc;
        }

        public static string ToJson(XmlDocument xml)
        {
            const Formatting format = Formatting.Indented;
            const bool omitRoot = false;
            var json = JsonConvert.SerializeXmlNode(xml, format, omitRoot);
            var tmp = JObject.Parse(json);
            var tmpRoot = tmp.Root.Last?.Value<JProperty>()?.Value;
            json = tmpRoot?.ToString(format);
            return json;
        }

        public static string ToJson(XmlDoc doc)
        {
            const Formatting format = Formatting.Indented;
            var settings = new JsonSerializerSettings
            {
                Formatting = format,
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(doc, settings);
            return json;
        }

        public static string Compare(string left, string right)
        {
            var jdp = new JsonDiffPatch();
            var result = jdp.Diff(left, right);
            return result;
        }

        public static string PatchNames(string json)
        {
            const string suffix = "Str";
            const Formatting format = Formatting.Indented;
            var obj = JObject.Parse(json);
            foreach (var child in obj.DescendantsAndSelf())
            {
                if (child is JObject childObj)
                {
                    var props = childObj.Properties()
                        .Select(p => (n: PatchName(p.Name, p.Value), r: p))
                        .OrderBy(p => p.r.Value is JObject or JArray)
                        .ThenBy(p => p.n.Replace(suffix, string.Empty))
                        .Reverse()
                        .ToArray();
                    foreach (var (name, prop) in props)
                    {
                        childObj.Remove(prop.Name);

                        var propName = name;
                        var propNameStr = $"{propName}{suffix}";

                        if (props.Any(p => p.r.Name.Equals(propNameStr)))
                            continue;
                        if (propName.Equals("Items"))
                            continue;
                        if (propName.Equals("Encoded"))
                            continue;

                        if (propName.EndsWith(suffix))
                            propName = propName[..^suffix.Length];
                        propName = prop.Value is JObject
                            ? propName.ToUpperInvariant()
                            : propName.StartsWith('#')
                                ? propName
                                : $"@{propName.ToLowerInvariant().TrimStart('@').Replace("_", "")}";

                        if (propName.Equals("@tag"))
                            propName = "TAG";
                        if (propName.Equals("@options"))
                            propName = "@items";

                        if (prop.Value is JObject { HasValues: false })
                            continue;
                        if (prop.Value is JArray { HasValues: false })
                            continue;

                        var propVal = prop.Value;
                        if (propVal is JArray { Count: 1 } ja)
                        {
                            if (((ja[0] as JValue)?.Value as string)?.Length == 0)
                                continue;
                            propName = prop.Name.ToUpperInvariant();
                            if (propName.EndsWith("XES"))
                                propName = propName.TrimEnd('S').TrimEnd('E');
                            else
                                propName = propName.TrimEnd('S');
                            propVal = ja[0];
                        }
                        if (propVal is JArray jaa)
                        {
                            foreach (var (i, content) in AsString(jaa))
                                if (i >= 0)
                                    jaa[i] = content;
                            for (var i = 0; i < jaa.Count; i++)
                                if (jaa[i].Type == JTokenType.Null)
                                    jaa[i] = string.Empty;
                        }
                        if (propVal is JObject { Count: 1 } jo)
                        {
                            var fakeArr = AsString(new JArray(jo));
                            if (fakeArr[0].idx >= 0)
                            {
                                propVal = fakeArr[0].tok;
                                if (propName.Equals("OPTION"))
                                    propName = "@item";
                            }
                        }
                        if (propVal is JValue jv)
                            switch (jv.Type)
                            {
                                case JTokenType.Null:
                                    continue;
                                case JTokenType.Integer:
                                    var intTxt = jv.Value<string>();
                                    propVal = intTxt;
                                    break;
                                case JTokenType.String:
                                    var strTxt = jv.Value<string>()
                                        .Replace("\r\n", "\n")
                                        .Trim();
                                    if (strTxt.Length > 72)
                                        strTxt = strTxt.Replace('\r' + "", string.Empty)
                                            .Replace('\n' + "", string.Empty);
                                    if (string.IsNullOrWhiteSpace(strTxt))
                                        continue;
                                    propVal = strTxt;
                                    if (strTxt!.EndsWith(".00"))
                                        propVal = strTxt[..^3];
                                    else if (strTxt!.EndsWith(".0"))
                                        propVal = strTxt[..^2];
                                    break;
                            }
                        if (propName.StartsWith("#"))
                            childObj.Add(new JProperty(propName, propVal));
                        else
                            childObj.AddFirst(new JProperty(propName, propVal));
                    }
                }
            }
            return obj.ToString(format);
        }

        private static (int idx, JToken tok)[] AsString(JContainer con)
        {
            const string contKey = "Content";
            return con.Select((p, idx) => (p as JObject)?.Count
                switch
                {
                    0 => (idx, string.Empty),
                    1 when ((JObject)p).ContainsKey(contKey) => (idx, p[contKey]),
                    _ => (-1, null)
                }).ToArray();
        }

        private static string PatchName(string name, JToken value)
        {
            var small = name.ToLowerInvariant();
            if (value is JArray { Count: >= 2 } && !small.EndsWith("s"))
            {
                if (small.EndsWith("x"))
                    name += "es";
                else
                    name += "s";
            }
            return name.Equals("Content") || name.Equals("EncodedStr") ? "#text" : name;
        }

        public static bool CheckAsJson(string file, XmlDoc doc, string folder)
        {
            var baseName = Path.GetFileNameWithoutExtension(file);
            var srcXml = PatchNames(ToJson(LoadXml(file)));
            var srcMem = PatchNames(ToJson(doc));

            var diff = Compare(srcXml, srcMem);
            var diffJsonFile = Path.Combine(folder, $"{baseName}.diff.json");
            if (string.IsNullOrWhiteSpace(diff))
                return true;

            Console.WriteLine($" --> {diffJsonFile}");
            var inJsonFile = Path.Combine(folder, $"{baseName}.in.json");
            var outJsonFile = Path.Combine(folder, $"{baseName}.out.json");
            File.WriteAllText(inJsonFile, srcXml, Encoding.UTF8);
            File.WriteAllText(outJsonFile, srcMem, Encoding.UTF8);
            File.WriteAllText(diffJsonFile, diff, Encoding.UTF8);
            return false;
        }

        public static void CleanUp(string folder)
        {
            foreach (var oldFile in Directory.EnumerateFiles(folder, "*.json"))
                File.Delete(oldFile);
        }
    }
}