using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CourseSAPD
{
    public class Parser
    {
        public MyQueue<Note> Queue;

        private readonly string _filePath;
        private readonly Encoding _encoding;

        public Parser(string filePath, Encoding encoding)
        {
            _filePath = filePath;
            _encoding = encoding;
            Queue = new MyQueue<Note>();
        }

        public MyQueue<Note> ParseFile()
        {
            var fileBytes = File.ReadAllBytes(_filePath);

            var fileElements = new List<List<byte>>();
            var tempElement = new List<byte>();

            foreach (var currentByte in fileBytes)
            {
                if (currentByte == 0)
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
                    Name = _encoding.GetString(fileElements[i].ToArray()),
                };

                byte[] amountBytes = fileElements[i + 1].GetRange(0, 2).ToArray();
                byte[] lawyerBytes = fileElements[i + 2].ToArray();
                note.Amount = BitConverter.ToUInt16(amountBytes, 0);
                note.Date = _encoding.GetString(fileElements[i + 1].GetRange(2, fileElements[i + 1].Count - 2).ToArray());
                note.Lawyer = _encoding.GetString(lawyerBytes);

                Array.Reverse(amountBytes);
                note.ByteAmountLawyer = lawyerBytes.Concat(amountBytes).ToArray();

                Queue.Add(note);
            }
            return Queue;
        }
    }
}
