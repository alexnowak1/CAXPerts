using System;

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
                cr.RunComparison(Environment.CurrentDirectory + "\\TestCases\\NumberParserExtended.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Folgender Fehler ist aufgetreten: " + ex.Message);
            }

        }
    }
}
