using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PatternRecognition
{
    public class TemplateReader
    {
        NumberTemplate template;

        public void ReadTemplates()
        {
            DirectoryInfo d = new DirectoryInfo(Environment.CurrentDirectory + "\\NumberTemplates\\");

            try
            {
                foreach (var file in d.GetFiles("*.txt"))
                {
                    if (!CheckFilenameIsNumeric(file.Name)) { throw new Exception("Template-Dateien müssen einen einstelligen numerischen Namen haben (z.B. 1.txt). Vorgang abgebrochen"); }

                    template = new NumberTemplate();
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        for (byte x = 0; x < 4; x++)
                        {
                            for (byte y = 0; y < 5; y++)
                            {
                                if ((char)sr.Peek() == 13) // /r/n überspringen
                                {
                                    sr.Read(); sr.Read();
                                }
                                template.Matrix[x, y] = (char)sr.Read();
                            }
                        }
                        template.Number = Convert.ToByte(file.Name.Substring(0, 1));
                    }
                    GlobalTemplates.TemplateList.Add(template);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CheckFilenameIsNumeric(string filename)
        {
            int number;
            return Int32.TryParse(filename.Substring(0, 1), out number);
        }
    }
}
