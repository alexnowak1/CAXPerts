using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PatternRecognition
{
    public class Comparer
    {
        private char[,] FileContents = new char[100, 100];
        private List<byte> ReturnList = new List<byte>();

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
                        FileContents[y, x] = (char)sr.Read();
                        x++;
                        if ((char)sr.Peek() == 13) // /r/n überspringen
                        {
                            sr.Read(); sr.Read();
                            y++;
                            x = 0;
                        }
                    }
                }

                for (byte y = 0; y < FileContents.GetLength(1); y++)
                {
                    for (byte x = 0; x < FileContents.GetLength(0); x++)
                    {
                        if (FileContents[y, x] == (char)'\0') //Ende erreicht, 4 Zeilen überspringen
                        {
                            y += 4;
                            x = 0;
                            if (y >= FileContents.GetLength(1)) { break; }
                        }
                        if (FileContents[y, x] != (char)32)//Leerzeichen überspringen
                        {
                            //Char gefunden. Vergleiche es mit dem ersten Char der vorhandenen Templates
                            foreach (var template in GlobalTemplates.templateList)
                            {
                                if (template.Matrix[0, 0] == FileContents[y, x]) //Wahrscheinlicher Treffer
                                {
                                    if (CompareWithTemplate(x, y, template))
                                    {
                                        //Treffer!
                                        ReturnList.Add(template.Number);
                                        x += 4;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return ReturnList;
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
                    if (FileContents[(y + cutY), (x + cutX)] != template.Matrix[cutY, cutX])
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
