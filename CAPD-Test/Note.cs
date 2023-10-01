using System;
using System.Text;

namespace CAPD_Test
{
    public struct Note
    {
        public byte[] Amount;
        public byte [] Lawyer; 
        public string Name;
        public string Date;

        public void Show()
        {
            string strLawyer = Encoding.GetEncoding("cp866").GetString(Lawyer);
            Console.WriteLine($"ФИО: {Name} Сумма: {BitConverter.ToUInt16(Amount, 0)} Дата: {Date} Адвокат: {strLawyer}");
        }
    }
}
