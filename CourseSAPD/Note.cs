using System.Text;
using System;

namespace CourseSAPD
{
    public struct Note
    {
        public byte[] ByteAmountLawyer;

        public string Name;
        public string Date;
        public ushort Amount;
        public string Lawyer;

        public void Show()
        {
            Console.WriteLine($"ФИО: {Name} Сумма: {Amount} Дата: {Date} Адвокат: {Lawyer}");
        }
    }
}
