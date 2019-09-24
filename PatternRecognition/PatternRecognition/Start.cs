using System;
using System.Collections.Generic;

namespace PatternRecognition
{
    class Start
    {
        static void Main(string[] args)
        {
            try
            {
                string _result = String.Empty;

                IComparer cr = new Comparer();
                var ret = cr.RunComparison(Environment.CurrentDirectory + "\\TestCases\\NumberParserExtended.txt");

                Console.Write("Folgende Zahlen wurden gefunden: ");
                foreach (var x in ret)
                {
                    _result += x + ",";
                }
                Console.Write(_result.Substring(0, _result.Length-1));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Folgender Fehler ist aufgetreten: " + ex.Message);
            }

        }
    }
}
