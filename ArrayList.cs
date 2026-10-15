using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsDev
{ //para cambiar el nombre de clases usar F2 arriba del nombre.
    internal class ArrayList<T> : IList<T>
    {
        public const int INITIAL_CAPACTIY = 10;
        private T[] data;
        private int index;
        public int Capacity { get; private set; }
        public int Size => index + 1;
        public bool Empty => index == -1;

        public ArrayList(IEnumerable<T> elements) : this()
        {
            foreach (var e in elements)
            {
                Add(e);
            }
        }

        public ArrayList(int capacity)
        {
            Capacity = capacity < INITIAL_CAPACTIY ? INITIAL_CAPACTIY : capacity;
            data = new T[Capacity];
            index = -1;
        }

        public ArrayList() : this(INITIAL_CAPACTIY) { }
        //enlazamineto de constructores es decir que un constructor se va a apoyar de otro para hacer su trabajo
        //Lo primero que hacemos es ejecutar el constructor que se esta llamado y luego uno tiene sus propias
        //llaves


        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Get(int index) => data[index];


        public void Set(int index, T element) => data[index] = element;


        public void Add(T element)
        {
            if (Size == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref data, Capacity);
            }
            data[++index] = element;

        }

        public void AddAll(T first, params T[] elements)
        {
            Add(first);

            foreach (T e in elements)
            {
                Add(e);
            }
        }

        public bool Contains(T element)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < Size; i++)
            {
                if (comparer.Equals(data[i], element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (Size == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref data, Capacity);
            }

            int indexToCopy = this.index + 1;
            while (indexToCopy > index)
            {
                data[indexToCopy] = data[indexToCopy - 1];
                indexToCopy--;
            }

            data[index] = element;
            this.index++;

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            int indexToCopy = index;
            while (indexToCopy < this.index)
            {
                data[indexToCopy] = data[indexToCopy + 1];
                indexToCopy++;
            }

            data[this.index] = default;
            this.index--;
        }

        public void Clear()
        {
            Capacity = INITIAL_CAPACTIY;
            data = new T[Capacity];
            index = -1;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Size; i++)
            {
                action(data[i]);
            }
        }

        public bool All(Predicate<T> condition)
        {
            for (int i = 0; i < Size; i++)
            {
                if (!condition(data[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Any(Predicate<T> condition)
        {
            for (int i = 0; i < Size; i++)
            {
                if (condition(data[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public int Count(Predicate<T> condition)
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                if (condition(data[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < Size; i++)
            {
                if (match(data[i]))
                {
                    return data[i];
                }
            }
            return default(T);
        }

        public IList<T> FindAll(Predicate<T> match)
        {
            var newList = new ArrayList<T>();
            for (int i = 0; i < Size; i++)
            {
                if (match(data[i]))
                {
                    newList.Add(data[i]);
                }
            }
            return newList;
        }

        public void Sort(Comparison<T> comparison)
        {
            for (int i = 0; i < Size - 1; i++)
            {
                for (int j = 0; j < Size -1; j++)
                {
                    if (comparison(data[j], data[j+1]) > 0)
                    {
                        T aux = data[j];
                        data[j] = data[j+1];
                        data[j+1] = aux;
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------

    }

}