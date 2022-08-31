using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Beycik.Model.Roots;

namespace Beycik.Model
{
    public static class XmlHelper
    {
        private static readonly XmlSerializer Serializer;

        static XmlHelper()
        {
            Serializer = new XmlSerializer(typeof(XmlDoc));
        }

        #region Errors
        private static ICollection<string> _errors;

        public static ICollection<string> Errors
        {
            get => _errors;
            set
            {
                if (_errors == null)
                {
                    Serializer.UnknownAttribute += OnUnknownAttribute;
                    Serializer.UnknownElement += OnUnknownElement;
                    Serializer.UnknownNode += OnUnknownNode;
                }
                _errors = value;
                if (_errors != null)
                    return;
                Serializer.UnknownAttribute -= OnUnknownAttribute;
                Serializer.UnknownElement -= OnUnknownElement;
                Serializer.UnknownNode -= OnUnknownNode;
            }
        }

        private static void OnUnknownNode(object sender, XmlNodeEventArgs e)
        {
            if (e.NodeType is XmlNodeType.Element or XmlNodeType.Attribute)
                return;
            OnUnknownXml(e.LineNumber, e.LinePosition, e.NodeType, e.Name,
                e.ObjectBeingDeserialized?.GetType(), e.Text);
        }

        private static void OnUnknownElement(object sender, XmlElementEventArgs e)
        {
            var name = (e.Element.Name + " " + e.ExpectedElements).Trim();
            OnUnknownXml(e.LineNumber, e.LinePosition, e.Element.NodeType,
                name, e.ObjectBeingDeserialized?.GetType(), e.Element.InnerText);
        }

        private static void OnUnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            var name = (e.Attr.Name + " " + e.ExpectedAttributes).Trim();
            OnUnknownXml(e.LineNumber, e.LinePosition, e.Attr.NodeType,
                name, e.ObjectBeingDeserialized?.GetType(), e.Attr.Value);
        }

        private static void OnUnknownXml(int line, int col, XmlNodeType xmlType,
            string xmlName, Type netType, string text)
        {
            _errors.Add($"({line:D3}:{col:D3}) [{xmlType}] {{{netType}}} '{xmlName}' \"{text}\"");
        }
        #endregion

        public static XmlDoc ReadFile(string filePath)
        {
            try
            {
                using var file = File.OpenRead(filePath);
                return Read(file);
            }
            catch (InvalidOperationException e)
            {
                if (_errors == null)
                    throw;
                var xmlPosStr = e.Message.Split('(').Last()
                    .Split(')').First().Split(',');
                var line = int.Parse(xmlPosStr[0]);
                var col = int.Parse(xmlPosStr[1]);
                var innerMess = e.InnerException?.Message ?? e.Message;
                var text = File.ReadLines(filePath).Skip(line - 2).Take(2);
                var content = string.Join(string.Empty, text).Trim();
                var debug = $"({line:D3}:{col:D3}) '{content}' \"{innerMess}\"";
                _errors.Add(debug);
                return null;
            }
        }

        private static XmlDoc Read(Stream input)
        {
            var doc = (XmlDoc)Serializer.Deserialize(input);
            return doc;
        }

        public static void WriteFile(string filePath, XmlDoc doc)
        {
            using var file = File.Create(filePath);
            Write(file, doc);
        }

        private static void Write(Stream output, XmlDoc doc)
        {
            var settings = new XmlWriterSettings { Indent = true };
            Serializer.Serialize(XmlWriter.Create(output, settings), doc);
        }
    }
}