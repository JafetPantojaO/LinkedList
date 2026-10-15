using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ListsDev
{
    internal class Program
    {
        static void Main(string[] args)
        {


            LinkedList<int> list = new LinkedList<int>();

            /*

            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(10);
            list.Add(-36);

            */


            list.AddAll(100, 200, 300, 400, 500);

            // list[4] = -360;

            Write("\n[");
            for (int i = 0; i < list.Size; i++)
            {
                Write($"{list[i]}, ");
            }
            Write("]");

            // list.Clear();
            // list.Insert(0, -20);
            // list.Insert(4, -20);
            // list.Insert(list.Size - 1 , -20);

            // ------------otra forma de recorrer la lista ---------------

            Write("\n[");
            foreach (int e in list)
            {
                Write($"{e}, ");
            }
            Write("]");
            
        }
    }
}