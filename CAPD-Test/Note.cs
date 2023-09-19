using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CAPD_Test
{
    public class Note
    {
        private string _name;
        private ushort _amount;
        private string _date;
        private string _lawyer;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ushort Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Lawyer
        {
            get { return _lawyer; }
            set { _lawyer = value; }
        }

        public void Show()
        {
            Console.WriteLine($"ФИО: {_name} Сумма: {_amount} Дата: {_date} Адвокат: {_lawyer}");
        }
    }
}
