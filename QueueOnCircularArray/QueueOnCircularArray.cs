using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueOnCircularArray
{
    public class QueueOnCircularArray<T> where T : IComparable<T>
    {
        private T[] _queue;
        // сколько выделено памяти (физическое пространство)
        private int _capacity;
        // реальное количество элементов в очереди (логическое пространство)
        private int _size;
        private int _head;
        private int _tail;

        public bool IsEmpty => _size == 0;

        public QueueOnCircularArray() 
        {
            _capacity = 0;
            _queue = new T[_capacity];
            _size = 0;
            _head = 0;
            _tail = 0;
        }
        
        public string Print()
        {
            string result = string.Empty;
            if(_size == 0)
                return result;

            if(_head < _tail)
            {
                for (int i = _head; i < _tail; i++)
                {
                    result += _queue[i] + " ";
                }
            }
            else
            {
                for (int i = _head; i < _capacity; i++)
                {
                    result += _queue[i] + " ";
                }
                for (int i = 0; i < _tail; i++)
                {
                    result += _queue[i];
                }
            }
            return result;
        }

        public void Push(T value)
        {
            if(_size == _queue.Length)
            {
                _capacity = (_capacity == 0) ? 4 : _capacity*2;
                T[] queueNew = new T[_capacity];
                if(_size > 0)
                {
                    if (_head < _tail)
                    {
                        Array.Copy(_queue, _head, queueNew, 0, _size);
                    }
                    else
                    {
                        Array.Copy
                            (_queue, _head, queueNew, 0, _queue.Length - _head);
                        Array.Copy
                            (_queue, 0, queueNew, _queue.Length - _head, _tail);
                    }
                }
                _queue = queueNew;
                _head = 0;
                _tail = (_size == _capacity) ? 0 : _size;
            }
            _queue[_tail] = value;
            _tail = (_tail + 1) % _capacity;
            _size++;
        }
        public T Pop()
        {
            ThrowExceptionIfEmptyQueue();
            T removedElement = _queue[_head];
            _head = (_head + 1) % _capacity;
            _size--;
            return removedElement;
        }

        public T Peek()
        {
            ThrowExceptionIfEmptyQueue();
            return _queue[_head];
        }

        public void Clear()
        {
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        private void ThrowExceptionIfEmptyQueue()
        {
            if (_size == 0)
                throw new Exception("Queue is empty!");
        }
    }
}
