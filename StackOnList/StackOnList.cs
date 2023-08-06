using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnList
{
    public class StackOnList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private LinkedList<T> _stack;

        public bool IsEmpty => _stack.Count == 0;

        public StackOnList()
        {
            _stack = new LinkedList<T>();
        }

        public string Print()
        {
            string result = string.Empty;
            foreach (T value in _stack) 
            {
                result += value + " ";
            }
            return result;
        }

        public void Push(T value)
        {
            _stack.AddLast(value);
        }
        public T Pop()
        {
            ThrowExceptionIfEmptyStack();
            T lastValue = _stack.Last.Value;
            _stack.RemoveLast();
            return lastValue;
        }

        public T Peek()
        {
            ThrowExceptionIfEmptyStack();
            return _stack.Last.Value;
        }

        public void Clear() 
        {
            _stack.Clear();
        }

        private void ThrowExceptionIfEmptyStack()
        {
            if (_stack.Count == 0)
                throw new Exception("Stack is empty!");
        }
    }
}
