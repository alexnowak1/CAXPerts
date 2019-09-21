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
                tr.ReadTemplate(Environment.CurrentDirectory + "TemplateFormat\\");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Folgender Fehler ist aufgetreten: " + ex.Message);
            }

        }
    }
}
