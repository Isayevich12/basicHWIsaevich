using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicHomeWork8
{
    /// <summary>
    /// Пользовательская очередь
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyQueue<T> : IEnumerable<T> // реализация интерфейса дает возможность тспользовать linq + foreach( в данной программе не используется, просто попробовал)
    {
        private List<T> MyList { get; set; } = new List<T>();

        public int Count { get { return this.MyList.Count; } }

        public void Enqueue(T item)
        {
            this.MyList.Add(item);
        }

        public T Dequeue()
        {
            var first = this.MyList.First();
            MyList.Remove(first);

            return first;
        }

        public T Peek()
        {
            return this.MyList.First();
        }

        public void Clear()
        {
            this.MyList.Clear();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.MyList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.MyList.GetEnumerator();
        }
    }
}
