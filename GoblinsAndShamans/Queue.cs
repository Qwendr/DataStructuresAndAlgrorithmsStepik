using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsAndShamans
{
    public class Queue<T> where T : IComparable<T>
    {
        private List<T> _queue;

        public bool IsEmpty => _queue.Count == 0;
        public int Count => _queue.Count;

        public Queue()
        {
            _queue = new List<T>();
        }

        public string Print()
        {
            string result = string.Empty;
            foreach (var item in _queue)
            {
                result += item + " ";
            }
            return result;
        }

        public void Enqueue(T value)
        {
            _queue.Add(value);
        }
        public void EnqueueMiddle(T value)
        {
            int middleIndex = _queue.Count / 2;
            _queue.Insert(middleIndex, value);
        }
        public T Dequeue()
        {
            ThrowExceptionIfEmptyQueue();
            T firstItem = _queue[0];
            _queue.RemoveAt(0);
            return firstItem;
        }

        public T Peek()
        {
            ThrowExceptionIfEmptyQueue();
            return _queue[0];
        }

        public void Clear()
        {
            _queue.Clear();
        }

        private void ThrowExceptionIfEmptyQueue()
        {
            if (_queue.Count == 0)
                throw new Exception("Queue is empty!");
        }
    }
}
