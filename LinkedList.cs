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

        public T this[int index] { 
            get => Get(index);                                                                                                 
            set => Set(index, value);   
        }

        public LinkedList()
        {
            first = null;
            Size = 0;
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


        //---------------------------------------------------------------------------------------------------------

        public T Get(int index)
        {
            if(index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();           
            }

            else
            {
                Node current = first;
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }  
                return current.Element;
            }
        }

        public void Set(int index, T element)
        {
            if(index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();           
            }
            else
            {
                Node current = first;
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }                  
                current.Next = new Node(element);
                Size++;     
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

            if(index < 0 || index >= Size)
            {
                throw new NotImplementedException();
            }
            else
            {
                Node current = first;

                for(int i = 0; i < index -1; i++)
                {
                    current = current.Next;

                }

                current.Next = new Node(element);


            }

        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public bool All(Predicate<T> condition)
        {
            throw new NotImplementedException();
        }

        public bool Any(Predicate<T> condition)
        {
            throw new NotImplementedException();
        }

        public int Count(Predicate<T> condition)
        {
            throw new NotImplementedException();
        }

        public T Find(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAll(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public void ForEach(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void Sort(Comparison<T> comparison)
        {
            throw new NotImplementedException();
        }
    }
}