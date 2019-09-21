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
                TemplateReader tr = new TemplateReader();
                tr.ReadTemplate(Environment.CurrentDirectory + "\\NumberTemplates\\");

                Comparer cr = new Comparer();
                var ret = cr.RunComparison(Environment.CurrentDirectory + "\\TestCases\\NumberParserExtended.txt");

                Console.Write("Folgende Zahlen wurden gefunden: ");
                foreach (var x in ret)
                {
                    Console.Write(x +",");
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Folgender Fehler ist aufgetreten: " + ex.Message);
            }

        }
    }
}
