using System;
using System.Collections.Generic;
using System.Text;

namespace PatternRecognition
{
    public class NumberTemplate
    {
        public char[,] Matrix { get; set; } = new char[4, 5];
        public byte Number { get; set; }
    }

    public static class GlobalTemplates
    {
        public static List<NumberTemplate> TemplateList = new List<NumberTemplate>();
    }
}
