using System.Collections.Generic;
using Beycik.Draw.Fonts.API;
using static Beycik.PDF.Tools.PdfConst;

// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

namespace Beycik.PDF.Visuals
{
    internal static class Precompiled
    {
        internal static readonly Dictionary<string, Dictionary<int, double>> LineHeight = new()
        {
            {
                Helvetica, new()
                {
                    { 5, 6.4 }, { 6, 7.7 }, { 7, 8.9 }, { 8, 10.19 },
                    { 9, 11.4 }, { 10, 12.7 }, { 11, 13.9 }, { 12, 15.2 },
                    { 13, 16.39 }, { 14, 17.7 }, { 15, 18.89 }, { 16, 20.2 },
                    { 17, 21.4 }, { 18, 22.7 }, { 19, 23.9 }, { 20, 25.3 }
                }
            }
        };

        internal static readonly Dictionary<string, Dictionary<FontStyle, Dictionary<int, double[]>>> CharWidth = new()
        {
            {
                Helvetica, new()
                {
                    {
                        FontStyle.Bold, new()
                        {
                            { 5, new double[] { } }
                        }
                    },
                    {
                        FontStyle.Italic, new()
                        {
                            { 5, new double[] { } }
                        }
                    },
                    {
                        FontStyle.Regular, new()
                        {
                            {
                                5, new[]
                                {
                                    3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8,
                                    3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 3.8, 1.4, 1.6,
                                    1.8, 2.8, 2.8, 4.4, 3.3, 1.0, 1.7, 1.7, 1.9, 2.9, 1.4, 1.7, 1.4, 1.4, 2.8, 2.8, 2.8,
                                    2.8, 2.8, 2.8, 2.8, 2.8, 2.8, 2.8, 1.4, 1.4, 2.9, 2.9, 2.9, 2.8, 5.1, 3.3, 3.3, 3.6,
                                    3.6, 3.3, 3.1, 3.9, 3.6, 1.4, 2.5, 3.3, 2.8, 4.1, 3.6, 3.9, 3.3, 3.9, 3.6, 3.3, 3.1,
                                    3.6, 3.3, 5.0, 3.3, 3.3, 3.1, 1.4, 1.4, 1.4, 2.2, 2.8, 1.7, 2.8, 2.8, 2.5, 2.8, 2.8,
                                    1.4, 2.8, 2.8, 1.2, 1.0, 2.5, 1.2, 4.0, 2.8, 2.8, 2.8, 2.8, 1.7, 2.5, 1.4, 2.8, 2.5,
                                    3.5, 2.4, 2.5, 2.5, 1.7, 1.2, 1.7, 2.9, 3.8, 2.8, 3.8, 1.1, 2.8, 1.7, 5.0, 2.8, 2.8,
                                    1.7, 5.0, 3.3, 1.7, 5.0, 3.8, 3.1, 3.8, 3.8, 1.1, 1.1, 1.7, 1.7, 1.8, 2.8, 5.0, 1.5,
                                    5.0, 2.5, 1.7, 4.7, 3.8, 2.5, 3.3, 1.4, 1.6, 2.8, 2.8, 2.8, 2.8, 1.2, 2.8, 1.7, 3.7,
                                    1.9, 2.8, 2.9, 1.7, 3.7, 2.8, 2.0, 2.7, 1.7, 1.7, 1.7, 2.9, 2.7, 1.4, 1.7, 1.7, 1.8,
                                    2.8, 4.2, 4.2, 4.2, 3.1, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 5.0, 3.6, 3.3, 3.3, 3.3, 3.3,
                                    1.4, 1.4, 1.4, 1.4, 3.6, 3.6, 3.9, 3.9, 3.9, 3.9, 3.9, 2.9, 3.9, 3.6, 3.6, 3.6, 3.6,
                                    3.3, 3.3, 3.1, 2.8, 2.8, 2.8, 2.8, 2.8, 2.8, 4.4, 2.5, 2.8, 2.8, 2.8, 2.8, 1.4, 1.4,
                                    1.4, 1.4, 2.8, 2.8, 2.8, 2.8, 2.8, 2.8, 2.8, 2.7, 3.1, 2.8, 2.8, 2.8, 2.8, 2.5, 2.8,
                                    2.5
                                }
                            },
                            {
                                6, new[]
                                {
                                    4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5,
                                    4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 4.5, 1.7, 1.9,
                                    2.1, 3.3, 3.3, 5.3, 4.0, 1.1, 2.0, 2.0, 2.3, 3.5, 1.7, 2.0, 1.7, 1.7, 3.3, 3.3, 3.3,
                                    3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 1.7, 1.7, 3.5, 3.5, 3.5, 3.3, 6.1, 4.0, 4.0, 4.3,
                                    4.3, 4.0, 3.7, 4.7, 4.3, 1.6, 3.0, 4.0, 3.3, 4.9, 4.3, 4.7, 4.0, 4.7, 4.3, 4.0, 3.8,
                                    4.3, 4.0, 6.0, 3.9, 4.0, 3.7, 1.7, 1.7, 1.7, 2.6, 3.3, 2.0, 3.3, 3.3, 3.0, 3.3, 3.3,
                                    1.7, 3.3, 3.3, 1.3, 1.3, 3.1, 1.3, 4.9, 3.3, 3.3, 3.3, 3.3, 2.0, 3.0, 1.7, 3.3, 3.1,
                                    4.3, 3.0, 2.9, 2.9, 2.0, 1.5, 2.0, 3.5, 4.5, 3.3, 4.5, 1.3, 3.3, 2.0, 6.0, 3.3, 3.3,
                                    2.0, 6.0, 4.0, 2.0, 6.0, 4.5, 3.7, 4.5, 4.5, 1.3, 1.3, 2.0, 2.0, 2.1, 3.3, 6.0, 1.9,
                                    6.0, 3.0, 2.0, 5.7, 4.5, 2.9, 4.0, 1.7, 1.9, 3.3, 3.3, 3.3, 3.3, 1.5, 3.3, 2.0, 4.4,
                                    2.2, 3.3, 3.5, 2.0, 4.4, 3.3, 2.4, 3.3, 2.0, 2.0, 2.0, 3.5, 3.2, 1.7, 2.0, 2.0, 2.2,
                                    3.3, 5.0, 5.0, 5.0, 3.7, 4.0, 4.0, 4.0, 4.0, 4.0, 4.0, 6.0, 4.3, 4.0, 4.0, 4.0, 4.0,
                                    1.7, 1.7, 1.7, 1.7, 4.3, 4.3, 4.7, 4.7, 4.7, 4.7, 4.7, 3.5, 4.7, 4.3, 4.3, 4.3, 4.3,
                                    4.0, 4.0, 3.7, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 5.3, 3.0, 3.3, 3.3, 3.3, 3.3, 1.7, 1.7,
                                    1.7, 1.7, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.7, 3.3, 3.3, 3.3, 3.3, 3.0, 3.3,
                                    3.0
                                }
                            },
                            {
                                7, new[]
                                {
                                    5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3,
                                    5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 1.9, 2.2,
                                    2.5, 3.9, 3.9, 6.2, 4.7, 1.3, 2.3, 2.3, 2.7, 4.1, 1.9, 2.3, 1.9, 1.9, 3.9, 3.9, 3.9,
                                    3.9, 3.9, 3.9, 3.9, 3.9, 3.9, 3.9, 1.9, 1.9, 4.1, 4.1, 4.1, 3.9, 7.1, 4.7, 4.7, 5.1,
                                    5.1, 4.7, 4.3, 5.4, 5.1, 1.9, 3.5, 4.7, 3.9, 5.7, 5.1, 5.4, 4.7, 5.4, 5.1, 4.7, 4.3,
                                    5.1, 4.7, 7.0, 4.5, 4.7, 4.3, 1.9, 1.9, 1.9, 3.1, 3.9, 2.3, 3.9, 3.9, 3.5, 3.9, 3.9,
                                    2.0, 3.9, 3.9, 1.6, 1.5, 3.5, 1.6, 5.9, 3.9, 3.9, 3.9, 3.9, 2.3, 3.5, 1.9, 3.9, 3.5,
                                    4.9, 3.4, 3.3, 3.5, 2.3, 1.7, 2.3, 4.1, 5.3, 3.9, 5.3, 1.6, 3.9, 2.3, 7.0, 3.9, 3.9,
                                    2.3, 7.2, 4.7, 2.3, 7.0, 5.3, 4.3, 5.3, 5.3, 1.6, 1.6, 2.3, 2.3, 2.5, 3.9, 7.0, 2.0,
                                    7.0, 3.5, 2.3, 6.6, 5.3, 3.5, 4.7, 1.9, 2.2, 3.9, 3.9, 3.9, 3.9, 1.7, 3.9, 2.3, 5.2,
                                    2.6, 3.9, 4.1, 2.3, 5.2, 3.9, 2.8, 3.8, 2.3, 2.3, 2.3, 4.0, 3.8, 1.9, 2.3, 2.3, 2.6,
                                    3.9, 5.8, 5.8, 5.8, 4.3, 4.7, 4.7, 4.7, 4.7, 4.7, 4.7, 7.0, 5.1, 4.7, 4.7, 4.7, 4.7,
                                    1.9, 1.9, 1.9, 1.9, 5.1, 5.1, 5.4, 5.4, 5.4, 5.4, 5.4, 4.1, 5.4, 5.1, 5.1, 5.1, 5.1,
                                    4.7, 4.7, 4.3, 3.9, 3.9, 3.9, 3.9, 3.9, 3.9, 6.2, 3.5, 3.9, 3.9, 3.9, 3.9, 1.9, 1.9,
                                    1.9, 1.9, 3.9, 3.9, 3.9, 3.9, 3.9, 3.9, 3.9, 3.8, 4.3, 3.9, 3.9, 3.9, 3.9, 3.5, 3.9,
                                    3.5
                                }
                            },
                            {
                                8, new[]
                                {
                                    6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0,
                                    6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 2.2, 2.5,
                                    2.8, 4.4, 4.4, 7.1, 5.3, 1.5, 2.7, 2.7, 3.1, 4.7, 2.2, 2.7, 2.2, 2.2, 4.4, 4.4, 4.4,
                                    4.4, 4.4, 4.4, 4.4, 4.4, 4.4, 4.4, 2.2, 2.2, 4.7, 4.7, 4.7, 4.4, 8.1, 5.3, 5.3, 5.8,
                                    5.8, 5.3, 4.9, 6.2, 5.8, 2.2, 4.0, 5.3, 4.4, 6.7, 5.8, 6.2, 5.3, 6.2, 5.8, 5.3, 5.0,
                                    5.8, 5.3, 7.9, 5.4, 5.2, 4.9, 2.2, 2.2, 2.2, 3.6, 4.4, 2.7, 4.4, 4.4, 4.0, 4.4, 4.4,
                                    2.3, 4.4, 4.4, 1.8, 1.7, 4.0, 1.8, 6.7, 4.4, 4.4, 4.4, 4.4, 2.7, 4.0, 2.2, 4.4, 4.1,
                                    5.7, 4.1, 3.9, 3.9, 2.7, 2.0, 2.7, 4.7, 6.0, 4.4, 6.0, 1.8, 4.4, 2.7, 8.0, 4.4, 4.4,
                                    2.7, 8.3, 5.3, 2.7, 8.0, 6.0, 4.9, 6.0, 6.0, 1.8, 1.8, 2.7, 2.7, 2.8, 4.4, 8.0, 2.4,
                                    8.0, 4.0, 2.7, 7.6, 6.0, 3.9, 5.3, 2.2, 2.5, 4.4, 4.4, 4.4, 4.4, 2.0, 4.4, 2.7, 5.9,
                                    3.0, 4.4, 4.7, 2.7, 5.9, 4.4, 3.2, 4.4, 2.7, 2.7, 2.7, 4.6, 4.3, 2.2, 2.7, 2.7, 2.9,
                                    4.4, 6.7, 6.7, 6.7, 4.9, 5.3, 5.3, 5.3, 5.3, 5.3, 5.3, 8.0, 5.8, 5.3, 5.3, 5.3, 5.3,
                                    2.2, 2.2, 2.2, 2.2, 5.8, 5.8, 6.2, 6.2, 6.2, 6.2, 6.2, 4.7, 6.2, 5.8, 5.8, 5.8, 5.8,
                                    5.3, 5.3, 4.9, 4.4, 4.4, 4.4, 4.4, 4.4, 4.4, 7.1, 4.0, 4.4, 4.4, 4.4, 4.4, 2.2, 2.2,
                                    2.2, 2.2, 4.4, 4.4, 4.4, 4.4, 4.4, 4.4, 4.4, 4.4, 4.9, 4.4, 4.4, 4.4, 4.4, 4.0, 4.4,
                                    4.0
                                }
                            },
                            {
                                9, new[]
                                {
                                    6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8,
                                    6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 6.8, 2.5, 2.8,
                                    3.2, 5.0, 5.0, 8.0, 6.0, 1.7, 3.0, 3.0, 3.5, 5.3, 2.5, 3.0, 2.5, 2.5, 5.0, 5.0, 5.0,
                                    5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 2.5, 2.5, 5.3, 5.3, 5.3, 5.0, 9.1, 6.0, 6.0, 6.5,
                                    6.5, 6.0, 5.5, 7.0, 6.5, 2.5, 4.5, 6.0, 5.0, 7.5, 6.5, 7.0, 6.0, 7.0, 6.5, 6.0, 5.5,
                                    6.5, 6.0, 8.9, 6.0, 5.9, 5.5, 2.5, 2.5, 2.5, 4.1, 5.0, 3.0, 5.0, 5.0, 4.5, 5.0, 5.0,
                                    2.6, 5.0, 5.0, 2.0, 2.0, 4.6, 2.0, 7.6, 5.0, 5.0, 5.0, 5.0, 3.0, 4.5, 2.5, 5.0, 4.5,
                                    6.3, 4.5, 4.3, 4.4, 3.0, 2.3, 3.0, 5.3, 6.8, 5.0, 6.8, 2.0, 5.0, 3.0, 9.0, 5.0, 5.0,
                                    3.0, 9.0, 6.0, 3.0, 9.0, 6.8, 5.5, 6.8, 6.8, 2.0, 2.0, 3.0, 3.0, 3.2, 5.0, 9.0, 2.8,
                                    9.0, 4.5, 3.0, 8.5, 6.8, 4.4, 6.0, 2.5, 2.8, 5.0, 5.0, 5.0, 5.0, 2.3, 5.0, 3.0, 6.6,
                                    3.3, 5.0, 5.3, 3.0, 6.6, 5.0, 3.6, 4.9, 3.0, 3.0, 3.0, 5.2, 4.8, 2.5, 3.0, 3.0, 3.3,
                                    5.0, 7.5, 7.5, 7.5, 5.5, 6.0, 6.0, 6.0, 6.0, 6.0, 6.0, 9.0, 6.5, 6.0, 6.0, 6.0, 6.0,
                                    2.5, 2.5, 2.5, 2.5, 6.5, 6.5, 7.0, 7.0, 7.0, 7.0, 7.0, 5.3, 7.0, 6.5, 6.5, 6.5, 6.5,
                                    6.0, 6.0, 5.5, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 8.0, 4.5, 5.0, 5.0, 5.0, 5.0, 2.5, 2.5,
                                    2.5, 2.5, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 4.9, 5.5, 5.0, 5.0, 5.0, 5.0, 4.5, 5.0,
                                    4.5
                                }
                            },
                            {
                                10, new[]
                                {
                                    7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5,
                                    7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 7.5, 2.8, 2.8,
                                    3.6, 5.6, 5.6, 8.9, 6.7, 1.9, 3.3, 3.3, 3.9, 5.8, 2.8, 3.3, 2.8, 2.8, 5.6, 5.6, 5.6,
                                    5.6, 5.6, 5.6, 5.6, 5.6, 5.6, 5.6, 2.8, 2.8, 5.8, 5.8, 5.8, 5.6, 10.2, 6.7, 6.7,
                                    7.2, 7.2, 6.7, 6.1, 7.8, 7.2, 2.8, 5.0, 6.7, 5.6, 8.3, 7.2, 7.8, 6.7, 7.8, 7.2, 6.7,
                                    6.2, 7.2, 6.7, 9.9, 6.6, 6.6, 6.1, 2.8, 2.8, 2.8, 4.3, 5.6, 3.3, 5.6, 5.6, 5.0, 5.6,
                                    5.6, 2.9, 5.5, 5.6, 2.2, 2.2, 5.0, 2.2, 8.4, 5.6, 5.6, 5.6, 5.5, 3.3, 5.0, 2.8, 5.6,
                                    4.9, 7.1, 4.9, 4.9, 4.9, 3.3, 2.6, 3.3, 5.8, 7.5, 5.6, 7.5, 2.2, 5.6, 3.3, 10.0,
                                    5.6, 5.6, 3.3, 10.0, 6.7, 3.3, 10.0, 7.5, 6.1, 7.5, 7.5, 2.2, 2.2, 3.3, 3.3, 3.5,
                                    5.6, 10.0, 3.1, 10.0, 5.0, 3.3, 9.4, 7.5, 4.9, 6.6, 2.8, 3.1, 5.6, 5.6, 5.6, 5.6,
                                    2.6, 5.6, 3.3, 7.4, 3.7, 5.6, 5.8, 3.3, 7.4, 5.5, 4.0, 5.5, 3.3, 3.3, 3.3, 5.8, 5.4,
                                    2.8, 3.3, 3.3, 3.7, 5.6, 8.3, 8.3, 8.3, 6.1, 6.7, 6.7, 6.7, 6.7, 6.7, 6.7, 10.0,
                                    7.2, 6.7, 6.7, 6.7, 6.7, 2.8, 2.8, 2.8, 2.8, 7.2, 7.2, 7.8, 7.8, 7.8, 7.8, 7.8, 5.8,
                                    7.8, 7.2, 7.2, 7.2, 7.2, 6.6, 6.7, 6.1, 5.6, 5.6, 5.6, 5.6, 5.6, 5.6, 8.9, 5.0, 5.6,
                                    5.6, 5.6, 5.6, 2.7, 2.7, 2.7, 2.7, 5.6, 5.6, 5.6, 5.6, 5.6, 5.6, 5.6, 5.5, 6.1, 5.6,
                                    5.6, 5.6, 5.6, 4.9, 5.6, 4.9
                                }
                            },
                            {
                                11, new[]
                                {
                                    8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3,
                                    8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 3.1, 2.8,
                                    3.9, 6.1, 6.1, 9.8, 7.3, 2.1, 3.7, 3.7, 4.3, 6.4, 3.1, 3.7, 3.1, 3.1, 6.1, 6.1, 6.1,
                                    6.1, 6.1, 6.1, 6.1, 6.1, 6.1, 6.1, 3.1, 3.1, 6.4, 6.4, 6.4, 6.1, 11.2, 7.3, 7.3,
                                    7.9, 7.9, 7.3, 6.7, 8.6, 7.9, 3.1, 5.5, 7.3, 6.1, 9.1, 7.9, 8.6, 7.3, 8.6, 7.9,
                                    7.3, 6.9, 7.9, 7.3, 10.6, 7.2, 7.3, 6.7, 3.1, 3.1, 3.1, 5.0, 6.1, 3.7, 6.1, 6.1,
                                    5.5, 6.1, 6.1, 3.1, 6.1, 6.1, 2.4, 2.4, 5.5, 2.4, 9.2, 6.1, 6.1, 6.1, 6.1, 3.7,
                                    5.5, 3.1, 6.1, 5.5, 7.7, 5.4, 5.3, 5.5, 3.7, 2.8, 3.7, 6.4, 8.3, 6.1, 8.3, 2.4,
                                    6.1, 3.7, 11.0, 6.1, 6.1, 3.7, 11.0, 7.3, 3.7, 11.0, 8.3, 6.7, 8.3, 8.3, 2.4, 2.4,
                                    3.7, 3.7, 3.9, 6.1, 11.0, 3.5, 11.0, 5.5, 3.7, 10.4, 8.3, 5.5, 7.3, 3.1, 3.4, 6.1,
                                    6.1, 6.1, 6.1, 2.8, 6.1, 3.7, 8.1, 4.1, 6.1, 6.4, 3.7, 8.1, 6.1, 4.4, 6.0, 3.7,
                                    3.7, 3.7, 6.3, 5.9, 3.1, 3.7, 3.7, 4.0, 6.1, 9.2, 9.2, 9.2, 6.7, 7.3, 7.3, 7.3,
                                    7.3, 7.3, 7.3, 11.0, 7.9, 7.3, 7.3, 7.3, 7.3, 3.1, 3.1, 3.1, 3.1, 7.9, 7.9, 8.6,
                                    8.6, 8.6, 8.6, 8.6, 6.4, 8.6, 7.9, 7.9, 7.9, 7.9, 7.3, 7.3, 6.7, 6.1, 6.1, 6.1,
                                    6.1, 6.1, 6.1, 9.8, 5.5, 6.1, 6.1, 6.1, 6.1, 3.1, 3.1, 3.1, 3.1, 6.1, 6.1, 6.1,
                                    6.1, 6.1, 6.1, 6.1, 6.0, 6.7, 6.1, 6.1, 6.1, 6.1, 5.5, 6.1, 5.5
                                }
                            },
                            {
                                12, new[]
                                {
                                    9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0,
                                    9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 9.0, 3.3, 3.1,
                                    4.3, 6.7, 6.7, 10.7, 8.0, 2.3, 4.0, 4.0, 4.7, 7.0, 3.3, 4.0, 3.3, 3.3, 6.7, 6.7,
                                    6.7, 6.7, 6.7, 6.7, 6.7, 6.7, 6.7, 6.7, 3.3, 3.3, 7.0, 7.0, 7.0, 6.7, 12.2, 8.0,
                                    8.0, 8.7, 8.7, 8.0, 7.3, 9.3, 8.7, 3.3, 6.0, 8.0, 6.7, 10.0, 8.7, 9.3, 8.0, 9.3,
                                    8.7, 8.0, 7.3, 8.7, 8.0, 11.6, 8.1, 7.7, 7.3, 3.3, 3.3, 3.3, 5.5, 6.7, 4.0, 6.7,
                                    6.7, 6.0, 6.7, 6.7, 3.3, 6.7, 6.7, 2.7, 2.7, 6.0, 2.7, 10.0, 6.7, 6.7, 6.7, 6.7,
                                    4.0, 6.0, 3.3, 6.7, 5.9, 8.5, 5.9, 5.7, 6.0, 4.0, 3.1, 4.0, 7.0, 9.0, 6.7, 9.0,
                                    2.7, 6.7, 4.0, 12.0, 6.7, 6.7, 4.0, 12.0, 8.0, 4.0, 12.0, 9.0, 7.3, 9.0, 9.0, 2.7,
                                    2.7, 4.0, 4.0, 4.2, 6.7, 12.0, 4.2, 12.0, 6.0, 4.0, 11.3, 9.0, 6.0, 8.0, 3.3, 3.7,
                                    6.7, 6.7, 6.7, 6.7, 3.1, 6.7, 4.0, 8.8, 4.4, 6.7, 7.0, 4.0, 8.8, 6.6, 4.8, 6.6,
                                    4.0, 4.0, 4.0, 6.9, 6.4, 3.3, 4.0, 4.0, 4.4, 6.7, 10.0, 10.0, 10.0, 7.3, 8.0, 8.0,
                                    8.0, 8.0, 8.0, 8.0, 12.0, 8.7, 8.0, 8.0, 8.0, 8.0, 3.3, 3.3, 3.3, 3.3, 8.7, 8.7,
                                    9.3, 9.3, 9.3, 9.3, 9.3, 7.0, 9.3, 8.7, 8.7, 8.7, 8.7, 8.0, 8.0, 7.3, 6.7, 6.7,
                                    6.7, 6.7, 6.7, 6.7, 10.7, 6.0, 6.7, 6.7, 6.7, 6.7, 3.3, 3.3, 3.3, 3.3, 6.7, 6.7,
                                    6.7, 6.7, 6.7, 6.7, 6.7, 6.6, 7.3, 6.7, 6.7, 6.7, 6.7, 6.0, 6.7, 6.0
                                }
                            },
                            {
                                13, new[]
                                {
                                    9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8,
                                    9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 9.8, 3.6, 3.4,
                                    4.6, 7.2, 7.2, 11.6, 8.7, 2.5, 4.3, 4.3, 5.1, 7.6, 3.6, 4.3, 3.6, 3.6, 7.2, 7.2,
                                    7.2, 7.2, 7.2, 7.2, 7.2, 7.2, 7.2, 7.2, 3.6, 3.6, 7.6, 7.6, 7.6, 7.2, 13.2, 8.7,
                                    8.7, 9.4, 9.4, 8.7, 7.9, 10.1, 9.4, 3.6, 6.5, 8.7, 7.2, 10.8, 9.4, 10.1, 8.7, 10.1,
                                    9.4, 8.7, 8.0, 9.4, 8.7, 12.6, 8.7, 8.4, 7.9, 3.6, 3.6, 3.6, 5.8, 7.2, 4.3, 7.2,
                                    7.2, 6.5, 7.2, 7.2, 3.6, 7.2, 7.2, 2.9, 3.0, 6.5, 2.9, 10.8, 7.2, 7.2, 7.2, 7.2,
                                    4.3, 6.5, 3.6, 7.2, 6.5, 9.1, 6.5, 6.3, 6.5, 4.3, 3.4, 4.3, 7.6, 9.8, 7.2, 9.8, 2.9,
                                    7.2, 4.3, 13.0, 7.2, 7.2, 4.3, 13.0, 8.7, 4.3, 13.0, 9.8, 7.9, 9.8, 9.8, 2.9, 2.9,
                                    4.3, 4.3, 4.6, 7.2, 13.0, 4.6, 13.0, 6.5, 4.3, 12.3, 9.8, 6.5, 8.7, 3.6, 4.0, 7.2,
                                    7.2, 7.2, 7.2, 3.4, 7.2, 4.3, 9.6, 4.8, 7.2, 7.6, 4.3, 9.6, 7.2, 5.2, 7.1, 4.3, 4.3,
                                    4.3, 7.5, 7.0, 3.6, 4.3, 4.3, 4.7, 7.2, 10.8, 10.8, 10.8, 7.9, 8.7, 8.7, 8.7, 8.7,
                                    8.7, 8.7, 13.0, 9.4, 8.7, 8.7, 8.7, 8.7, 3.6, 3.6, 3.6, 3.6, 9.4, 9.4, 10.1, 10.1,
                                    10.1, 10.1, 10.1, 7.6, 10.1, 9.4, 9.4, 9.4, 9.4, 8.7, 8.7, 7.9, 7.2, 7.2, 7.2, 7.2,
                                    7.2, 7.2, 11.6, 6.5, 7.2, 7.2, 7.2, 7.2, 3.6, 3.6, 3.6, 3.6, 7.2, 7.2, 7.2, 7.2,
                                    7.2, 7.2, 7.2, 7.1, 7.9, 7.2, 7.2, 7.2, 7.2, 6.5, 7.2, 6.5
                                }
                            },
                            {
                                14, new[]
                                {
                                    10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5,
                                    10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5, 10.5,
                                    10.5, 10.5, 10.5, 10.5, 3.9, 3.9, 5.0, 7.8, 7.8, 12.4, 9.3, 2.7, 4.7, 4.7, 5.4, 8.2,
                                    3.9, 4.7, 3.9, 3.9, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 3.9, 3.9, 8.2,
                                    8.2, 8.2, 7.8, 14.2, 9.3, 9.3, 10.1, 10.1, 9.3, 8.6, 10.9, 10.1, 3.9, 7.0, 9.3, 7.8,
                                    11.7, 10.1, 10.9, 9.3, 10.9, 10.1, 9.3, 8.5, 10.1, 9.3, 13.2, 9.3, 9.1, 8.6, 3.9,
                                    3.9, 3.9, 6.2, 7.8, 4.7, 7.8, 7.8, 7.0, 7.8, 7.8, 3.9, 7.8, 7.8, 3.1, 3.0, 7.0, 3.1,
                                    11.7, 7.8, 7.8, 7.8, 7.8, 4.7, 7.0, 3.9, 7.8, 7.1, 9.9, 7.0, 6.7, 7.0, 4.7, 3.5,
                                    4.7, 8.2, 10.5, 7.8, 10.5, 3.1, 7.8, 4.7, 14.0, 7.8, 7.8, 4.7, 14.0, 9.3, 4.7,
                                    14.0, 10.5, 8.6, 10.5, 10.5, 3.1, 3.1, 4.7, 4.7, 4.9, 7.8, 14.0, 5.0, 14.0, 7.0,
                                    4.7, 13.2, 10.5, 7.0, 9.3, 3.9, 4.6, 7.8, 7.8, 7.8, 7.8, 3.5, 7.8, 4.7, 10.3, 5.2,
                                    7.8, 8.2, 4.7, 10.3, 7.7, 5.6, 7.7, 4.7, 4.7, 4.7, 8.1, 7.5, 3.9, 4.7, 4.7, 5.1,
                                    7.8, 11.7, 11.7, 11.7, 8.6, 9.3, 9.3, 9.3, 9.3, 9.3, 9.3, 14.0, 10.1, 9.3, 9.3,
                                    9.3, 9.3, 3.9, 3.9, 3.9, 3.9, 10.1, 10.1, 10.9, 10.9, 10.9, 10.9, 10.9, 8.2, 10.9,
                                    10.1, 10.1, 10.1, 10.1, 9.3, 9.3, 8.6, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 12.4, 7.0,
                                    7.8, 7.8, 7.8, 7.8, 3.9, 3.9, 3.9, 3.9, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 7.8, 7.7,
                                    8.6, 7.8, 7.8, 7.8, 7.8, 7.0, 7.8, 7.0
                                }
                            },
                            {
                                15, new[]
                                {
                                    11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3,
                                    11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3, 11.3,
                                    11.3, 11.3, 11.3, 11.3, 4.2, 3.9, 5.3, 8.3, 8.3, 13.3, 10.0, 2.9, 5.0, 5.0, 5.8,
                                    8.8, 4.2, 5.0, 4.2, 4.2, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 4.2,
                                    4.2, 8.8, 8.8, 8.8, 8.3, 15.2, 10.0, 10.0, 10.8, 10.8, 10.0, 9.2, 11.7, 10.8, 4.2,
                                    7.5, 10.0, 8.3, 12.5, 10.8, 11.7, 10.0, 11.7, 10.8, 10.0, 9.3, 10.8, 10.0, 14.2,
                                    9.9, 10.0, 9.2, 4.2, 4.2, 4.2, 6.8, 8.3, 5.0, 8.3, 8.3, 7.5, 8.3, 8.3, 4.2, 8.3,
                                    8.3, 3.3, 3.3, 7.5, 3.3, 12.5, 8.3, 8.3, 8.3, 8.3, 5.0, 7.5, 4.2, 8.3, 7.5, 10.5,
                                    7.4, 7.3, 7.5, 5.0, 3.7, 5.0, 8.8, 11.3, 8.3, 11.3, 3.3, 8.3, 5.0, 15.0, 8.3, 8.3,
                                    5.0, 15.0, 10.0, 5.0, 15.0, 11.3, 9.2, 11.3, 11.3, 3.3, 3.3, 5.0, 5.0, 5.3, 8.3,
                                    15.0, 5.3, 15.0, 7.5, 5.0, 14.2, 11.3, 7.5, 10.0, 4.2, 4.7, 8.3, 8.3, 8.3, 8.3,
                                    3.7, 8.3, 5.0, 11.1, 5.6, 8.3, 8.8, 5.0, 11.1, 8.3, 6.0, 8.2, 5.0, 5.0, 5.0, 8.6,
                                    8.1, 4.2, 5.0, 5.0, 5.5, 8.3, 12.5, 12.5, 12.5, 9.2, 10.0, 10.0, 10.0, 10.0, 10.0,
                                    10.0, 15.0, 10.8, 10.0, 10.0, 10.0, 10.0, 4.2, 4.2, 4.2, 4.2, 10.8, 10.8, 11.7,
                                    11.7, 11.7, 11.7, 11.7, 8.8, 11.7, 10.8, 10.8, 10.8, 10.8, 10.0, 10.0, 9.2, 8.3,
                                    8.3, 8.3, 8.3, 8.3, 8.3, 13.3, 7.5, 8.3, 8.3, 8.3, 8.3, 4.2, 4.2, 4.2, 4.2, 8.3,
                                    8.3, 8.3, 8.3, 8.3, 8.3, 8.3, 8.2, 9.2, 8.3, 8.3, 8.3, 8.3, 7.5, 8.3, 7.5
                                }
                            }
                        }
                    },
                }
            }
        };
    }
}