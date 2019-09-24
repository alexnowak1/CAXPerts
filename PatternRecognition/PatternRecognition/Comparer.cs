using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PatternRecognition
{
    public class Comparer
    {
        private char[,] fileContents = new char[100, 100];
        private List<byte> returnList = new List<byte>();

        public Comparer()
        {
            if (GlobalTemplates.TemplateList.Count == 0) //Templates nur einmal aus Dateien laden
            {
                TemplateReader tr = new TemplateReader();
                tr.ReadTemplates();
            }
        }

        public List<byte> RunComparison(string File)
        {
            try
            {
                using (StreamReader sr = new StreamReader(File))
                {
                    byte x = 0;
                    byte y = 0;

                    while (!sr.EndOfStream)
                    {
                        //Datei in Array einlesen
                        fileContents[y, x] = (char)sr.Read();
                        x++;
                        if ((char)sr.Peek() == 13) // /r/n überspringen
                        {
                            sr.Read(); sr.Read();
                            y++;
                            x = 0;
                        }
                    }
                }

                for (byte y = 0; y < fileContents.GetLength(1); y++)
                {
                    for (byte x = 0; x < fileContents.GetLength(0); x++)
                    {
                        if (fileContents[y, x] == (char)'\0') //Ende erreicht, 4 Zeilen überspringen
                        {
                            y += 4;
                            x = 0;
                            if (y >= fileContents.GetLength(1)) { break; }
                        }
                        if (fileContents[y, x] != (char)32) //Leerzeichen überspringen
                        {
                            //Char gefunden. Vergleiche es mit dem ersten Char der vorhandenen Templates
                            foreach (var template in GlobalTemplates.TemplateList)
                            {
                                if (template.Matrix[0, 0] == fileContents[y, x]) //Wahrscheinlicher Treffer
                                {
                                    if (CompareWithTemplate(x, y, template))
                                    {
                                        //Treffer!
                                        returnList.Add(template.Number);
                                        x += 4;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return returnList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool CompareWithTemplate(byte x, byte y, PatternRecognition.NumberTemplate template)
        {
            for (byte cutY = 0; cutY < 4; cutY++)
            {
                for (byte cutX = 0; cutX < 5; cutX++)
                {
                    if (fileContents[(y + cutY), (x + cutX)] != template.Matrix[cutY, cutX])
                    {
                        //Kein Treffer mehr!
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
