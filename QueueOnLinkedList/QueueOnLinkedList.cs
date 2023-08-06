using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueOnLinkedList
{
    public class QueueOnLinkedList<T> where T : IComparable<T>
    {
        private LinkedList<T> _queue;
        
        public bool IsEmpty => _queue.Count == 0;

        public QueueOnLinkedList()
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

        public void Push(T value)
        {
            _queue.AddLast(value);
        }
        public T Pop() 
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
