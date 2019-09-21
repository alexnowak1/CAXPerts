using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PatternRecognition
{
    public class Comparer
    {
        public void RunComparison(string File)
        {
            using (StreamReader sr = new StreamReader(File))
            {
                while (!sr.EndOfStream)
                {
                    char current = (char)sr.Read();
                    if (current != 32) //Leerzeichen überspringen
                    {
                        foreach (var template in NumberTemplateCollection.templateList)
                        {
                            if (current == template.Matrix[0,0]) //Erster Char ist ein treffer
                            {
                                

                            }
                        }
                    }
                }
            }
        }
    }
}
