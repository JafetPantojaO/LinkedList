using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ListsDev
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public double Grade { get; }

        public Student(int id, string name, double grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new ArrayList<Student>()
            {
                new Student(4561, "Dante", 99),
                new Student(2237, "Brandon", 88.62),
                new Student(4573, "Pedro", 88.62),
                new Student(1237, "Pablo", 88.62),
                new Student(2675, "Jose", 88.62),
            };

            students.Sort((x, y) => x.Id.CompareTo(y.Id)); //comparar id's de los estudiantes
            foreach (var s in students)
            {
                WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
            WriteLine("");

            students.Sort((x, y) => x.Name.CompareTo(y.Name)); //comparar nombres de los estudiantes
            foreach (var s in students)
            {
                WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
            WriteLine("");

            students.Sort((x, y) => x.Grade.CompareTo(y.Grade)); //comparar calificaciones de los estudiantes
            foreach (var s in students)
            {
                WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
            WriteLine("");

            students.Sort((x, y) => y.Grade.CompareTo(x.Grade)); //comparar calificaciones de los estudiantes de mayor a menor
            foreach (var s in students)
            {
                WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
            WriteLine("");

            students.FindAll(s => s.Grade > 60).Sort((x, y) => y.Grade.CompareTo(x.Grade)); //comparar calificaciones de los estudiantes de mayor a menor y filtrar los que tienen calificación mayor a 60
            foreach (var s in students)
            {
                WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
            WriteLine("");

            // LinkedList<int> datos;
            // otra clase de lista diferente a List<>
            // la lista que normalmene se usa como List<> realmente es un ArrayList<> ya que es un arreglo 
            // con su implicaciones

            /*
            var list = new LinkedList<int>();

            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(10);
            list.Add(-36);

            Write("\n[ ");
            foreach (int e in list)
            {
                Write($"{e}, ");
            }
            Write("]");


            */


            var list = new ArrayList<int>(
                new int[] { 1, -3, 5, 0, 35, -53, 27, 72, 24, 0, 1 });

            list.Sort((x, y) => (x* x > y * y ? 1 : (x * x == y * y ? 0 : -1)));
            Write("\n[");
            list.ForEach(e => Write($" {e} "));
            Write("]\n");

            list.Sort((x, y) => (x > y ? 1 : (x == y ? 0 : -1)));
            Write("\n[");
            list.ForEach(e => Write($" {e} "));
            Write("]\n");

            list.Sort((x, y) => x.CompareTo(y));
            Write("\n[");
            list.ForEach(e => Write($" {e} "));
            Write("]\n");


            int sum = 0;
            list.ForEach(e => sum += e);

            WriteLine($"\nPromedio: {sum / (double)list.Size}");

            WriteLine($"Todos son positivos: {list.All(e => e > 0)}");

            WriteLine($"Hay algun negativo: {list.Any(e => e < 0)}");

            WriteLine($"Hay algun cero: {list.Any(e => e == 0)}");

            WriteLine($"# de positivos: {list.Count(e => e > 0)}");
            WriteLine($"# de negativos: {list.Count(e => e < 0)}");
            WriteLine($"# de ceros: {list.Count(e => e == 0)}");

            WriteLine($"Un # mayor a 50: {list.Find(e => e > 50)}");
            WriteLine($"Un # mayor a 50 (magnitud): {list.Find(e => e > 50 || e < -50)}");

            Write("\nPositivos: [");
            list.FindAll(e => e > 0).ForEach(e => Write($" {e} "));
            WriteLine("]");
            Write("\nNegativos: [");
            list.FindAll(e => e < 0).ForEach(e => Write($" {e} "));
            WriteLine("]");

            //**************************************************************************************************
            //
            /*
            ArrayList<int> list = new ArrayList<int>();

            list.Add(10);
            list.Add(-4);
            list.Add(5);
            list.Add(27);
            list.Add(10);
            list.Add(-36);

            list.AddAll(100, 200, 300, 400, 500);

            list[4] = -360;

            Write("\n[");
            for (int i = 0; i < list.Size; i++)
            {
                Write($"{list[i]}, ");
            }
            Write("]");

            // list.Clear();
            // list.Insert(0, -20);
            list.Insert(4, -20);
            // list.Insert(list.Size - 1 , -20);

            // ------------otra forma de recorrer la lista ---------------

            Write("\n[");
            foreach (int e in list)
            {
                Write($"{e}, ");
            }
            Write("]");
            */
        }
    }
}