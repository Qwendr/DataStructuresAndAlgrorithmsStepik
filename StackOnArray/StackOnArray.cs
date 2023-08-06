using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnArray
{
    public class StackOnArray<T> where T : IComparable<T>
    {
        private T[] _stack;

        private int _size = 0;
        public bool IsEmpty => _size == 0;

        private int _timesIncreaseArraySize = 2;
        private int _defaultArraySizeIfIncrease = 4;

        public StackOnArray()
        {
            _stack = new T[0];
        }

        public string Print()
        {
            string result = string.Empty;
            for (int i = 0; i < _size; i++)
            {
                result += _stack[i] + " ";
            }
            return result;
        }

        public void Push(T value)
        {
            if (_size == _stack.Length)
                IncreaseArray();
            _stack[_size] = value;
            _size++;
        }
        public T Pop()
        {
            ThrowExceptionIfEmptyStack();
            T lastItem = _stack[--_size];
            return lastItem;
        }
        private void IncreaseArray()
        {
            int newCount = _size*_timesIncreaseArraySize;
            if (_size == 0)
                newCount = _defaultArraySizeIfIncrease;
            T[] newStack = new T[newCount];
            for (int i = 0; i < _size; i++)
            {
                newStack[i] = _stack[i];
            }
            _stack = newStack;
        }

        public T Peek()
        {
            ThrowExceptionIfEmptyStack();
            return _stack[_size - 1];
        }

        public void Clear()
        {
            _size = 0;
        }

        private void ThrowExceptionIfEmptyStack()
        {
            if (IsEmpty)
                throw new Exception("Stack is empty!");
        }
    }
}
