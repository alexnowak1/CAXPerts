using System;
using System.Collections.Generic;
using System.Text;

namespace PatternRecognition
{
    public class NumberTemplate
    {
        private char[,] _Matrix = new char[4, 5];
        public char[,] Matrix
        {
            get { return _Matrix; }
            set { _Matrix = value; }
        }

        public byte Number { get; set; }
    }

    public static class GlobalTemplates
    {
        public static List<NumberTemplate> templateList = new List<NumberTemplate>();
    }
}
