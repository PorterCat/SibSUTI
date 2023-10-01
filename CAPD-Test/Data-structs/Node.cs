using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPD_Test.Data_structs
{
    internal class Node<T> 
    {
        public Node<T> Next;
        public T Value;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
