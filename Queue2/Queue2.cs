using System;
using System.Collections.Generic;

namespace Queue2
{
    public class Queue2<T> where T : IComparable<T>
    {
        private LinkedList<T> _queue;

        public int Count => _queue.Count;
        public bool IsEmpty => _queue.Count == 0;

        public Queue2()
        {
            _queue = new LinkedList<T>();
        }

        public string Print()
        {
            string result = string.Empty;
            foreach (T item in _queue)
            {
                result += item + " ";
            }
            return result;
        }

        public void Enqueue(T value)
        {
            _queue.AddLast(value);
        }
        public T Dequeue()
        {
            ThrowExceptionIfEmptyQueue();
            T firstValue = _queue.First();
            _queue.RemoveFirst();
            return firstValue;
        }

        public T Peek()
        {
            return _queue.First.Value;
        }

        public void Clear()
        {
            _queue.Clear();
        }

        private void ThrowExceptionIfEmptyQueue()
        {
            if (IsEmpty)
                throw new Exception("Queue is empty!");
        }
    }
}
