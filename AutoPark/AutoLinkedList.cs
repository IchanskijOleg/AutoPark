using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    class AutoLinkedList : IEnumerable
    {
        public AutoNodeLinkedList Head { get; set; }
        public AutoNodeLinkedList Tail { get; set; }
        public void AddFirst(Bus data)
        {
            AutoNodeLinkedList node = new AutoNodeLinkedList { Data = data };
            if (Head == null) { Head = node; Tail = node; }
            else
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }
        }
        public void AddLast(Bus data)
        {
            AutoNodeLinkedList node = new AutoNodeLinkedList { Data = data };
            if (Head == null) { Head = node; Tail = node; }
            else
            {
                //      AutoNodeLinkedList current = Head;
                //      while (current.Next != null)
                //      {                    
                //          current = current.Next;
                //      }
                //      current.Next = node;
                //      node.Prev = current;
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
        }
        public Bus GetDataByRoute(int route)
        {
            AutoNodeLinkedList current = Head;
            while (current != null)
            {
                if (current.Data.Route == route) return current.Data;
                current = current.Next;
            }
            return null;
        }
        public void InsertDataByRouteAfter(int route, Bus data)
        {
            AutoNodeLinkedList node = new AutoNodeLinkedList { Data = data };
            AutoNodeLinkedList current = Head;
            while (current != null)
            {
                if (current.Data.Route == route)
                {
                    node.Next = current.Next;
                    node.Prev = current;
                    current.Next.Prev = node;
                    current.Next = node;
                }
                current = current.Next;
            }
        }
        public Bus RemoveDataByRoute(int route)
        {
            AutoNodeLinkedList current = Head;
            while (current != null)
            {
                if (current.Data.Route == route)
                {
                    if (current == Head)
                    {
                        Head = Head.Next;
                        Head.Prev = null;
                    }
                    else
                    if (current == Tail)
                    {
                        Tail = Tail.Prev;
                        Tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    return current.Data;
                }

                current = current.Next;
            }
            return null;
        }
        public Bus Get(int n)
        {
            AutoNodeLinkedList current = Head;
            int i = 0;
            while (current != null)
            {
                if (i == n) return current.Data;
                current = current.Next;
                i++;
            }
            return null;
        }
        public void Print()
        {
            AutoNodeLinkedList current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new EnumeratorAutoLinkedList(this);
            //AutoLinkedList[] lst = new AutoLinkedList[1];
            //foreach (var item in lst)
            //{
            //    yield return item;
            //}
        }

        //   IEnumerator<Bus> IEnumerable<Bus>.GetEnumerator()
        //    {
        //       return new EnumeratorAutoLinkedList<Bus>();
        //}

        private class EnumeratorAutoLinkedList : IEnumerator
        {
            AutoLinkedList list;
            AutoNodeLinkedList current;
            public EnumeratorAutoLinkedList(AutoLinkedList list)
            {
                this.list = list;
            }
            public object Current
            {
                get
                {
                    return current.Data;
                }
            }

            public bool MoveNext()
            {
                if (current == null) current = list.Head;
                else current = current.Next;
                while (current != null && current.Data.Id % 2 != 0) current = current.Next;
                return current != null;
            }

            public void Reset()
            {
                current = list.Head;
            }
        }
    }
}

