using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SAPD_Course
{
    internal class Parsing
    {
        private static readonly Encoding _cpp866 = Encoding.GetEncoding("cp866");

        private static readonly string _filePath = @"C:\Programming\CAPD-Test\testBase3.dat";

        public static List<Note> ParseFile(List<Note> notes)
        {
            var fileBytes = File.ReadAllBytes(_filePath);

            var fileElements = new List<List<byte>>();
            var tempElement = new List<byte>();

            foreach (var currentByte in fileBytes)
            {
                if(currentByte == 0)
                {
                    fileElements.Add(tempElement);
                    tempElement = new List<byte>();
                    continue;
                }
                tempElement.Add(currentByte);
            }

            for (int i = 0; i < fileElements.Count; i += 3)
            {
                var note = new Note
                {
                    Name = _cpp866.GetString(fileElements[i].ToArray()),
                    Amount = BitConverter.ToUInt16(fileElements[i + 1].GetRange(0, 2).ToArray(), 0),
                    Date = _cpp866.GetString(fileElements[i + 1].GetRange(2, fileElements[i + 1].Count - 2).ToArray()),
                    Lawyer = _cpp866.GetString(fileElements[i + 2].ToArray())
                };

                notes.Add(note);
            }

            return notes;
        }
    }
}