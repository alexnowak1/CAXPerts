using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PatternRecognition
{
    public class TemplateReader
    {
        readonly NumberTemplate template;
        readonly NumberTemplateCollection templateList;

        public TemplateReader()
        {
            template = new NumberTemplate();
            templateList = new NumberTemplateCollection();
        }

        public void ReadTemplate(string Path)
        {
            DirectoryInfo d = new DirectoryInfo(Path);

            try
            {
                foreach (var file in d.GetFiles("*.txt"))
                {
                    if (!CheckFilenameIsNumeric(file.Name)) { throw new Exception("Template-Dateien müssen einen einstelligen numerischen Namen haben (z.B. 1.txt). Vorgang abgebrochen"); }

                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        for (byte x = 0; x < 4; x++)
                        {
                            for (byte y = 0; y < 5; y++)
                            {
                                if (sr.Peek() == 13 || sr.Peek() == 10)
                                {
                                    sr.Read(); sr.Read(); //Newline-Chars überspringen
                                }
                                template.Matrix[x, y] = (char)sr.Read();
                            }
                        }
                        template.Number = Convert.ToByte(file.Name.Substring(0, 1));
                    }
                    templateList.templateList.Add(template);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CheckFilenameIsNumeric(string Filename)
        {
            int number;
            return Int32.TryParse(Filename.Substring(0, 1), out number);
        }
    }
}
