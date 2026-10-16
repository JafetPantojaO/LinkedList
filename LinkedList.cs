using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsDev
{
    public class LinkedList<T> : IList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element) : this(element, null) { }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
        }

        private Node first;

        public int Size { get; private set; }

        public bool Empty => first == null;

        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public LinkedList()
        {
            first = null;
            Size = 0;
        }

        public LinkedList(IEnumerable<T> elements) : this()
        {
            foreach (var e in elements)
            {
                Add(e);
            }
        }

        public void Add(T element)
        {
            if (Empty)
            {
                first = new Node(element);
            }
            else
            {
                Node lastNode = first;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                lastNode.Next = new Node(element);
            }
            Size++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Size > 0)
            {
                Node currentNode = first;

                do
                {
                    yield return currentNode.Element;
                    currentNode = currentNode.Next;
                }
                while (currentNode != null);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node current = first;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Element;
            }
        }

        public void Set(int index, T element)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node current = first;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Element = element;
            }
        }

        public void AddAll(T first, params T[] elements)
        {
            Add(first);

            foreach (T e in elements)
            {
                Add(e);
            }
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Node newNode = new Node(element);
                newNode.Next = first;
                first = newNode;
            }
            else
            {
                Node current = first;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                Node newNode = new Node(element);
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            Size++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                first = first.Next;
            }
            else
            {
                Node previous = first;
                for (int i = 0; i < index - 1; i++)
                {
                    previous = previous.Next;
                }

                Node current = previous.Next;
                previous.Next = current.Next;

                current.Next = null;
                current.Element = default;
            }

            Size--;
        }

        public void Clear()
        {
            first = null;
            Size = 0;
        }

        public bool Contains(T element)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            Node current = first;
            while (current != null)
            {
                if (comparer.Equals(current.Element, element))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public bool All(Predicate<T> condition)
        {
            Node current = first;
            while (current != null)
            {
                if (!condition(current.Element))
                {
                    return false;
                }
                current = current.Next;
            }
            return true;
        }

        public bool Any(Predicate<T> condition)
        {
            Node current = first;
            while (current != null)
            {
                if (condition(current.Element))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Count(Predicate<T> condition)
        {
            int count = 0;
            Node current = first;
            while (current != null)
            {
                if (condition(current.Element))
                {
                    count++;
                }
                current = current.Next;
            }
            return count;
        }

        public T Find(Predicate<T> match)
        {
            
            Node current = first;
            while (current != null)
            {
                if (match(current.Element))
                {
                    return current.Element;
                }
                current = current.Next;
            }  
            return default(T);
        }

        public IList<T> FindAll(Predicate<T> match)
        {
            var newList = new LinkedList<T>();
            Node current = first;
            while (current != null)
            {
                if (match(current.Element))
                {
                    newList.Add(current.Element);
                }
                current = current.Next;
            }
            return newList;
        }

        public void ForEach(Action<T> action)
        {
            Node current = first;
            while (current != null)
            {
                action(current.Element);
                current = current.Next;
            }
        }

        public void Sort(Comparison<T> comparison)
        {
            for (int i = 1; i < Size; i++)
            {
                T currentElement = this[i];
                int j = i - 1;

                while (j >= 0 && comparison(this[j], currentElement) > 0)
                {
                    this[j + 1] = this[j];
                    j--;
                }

                this[j + 1] = currentElement;
            }
        }
    }
}