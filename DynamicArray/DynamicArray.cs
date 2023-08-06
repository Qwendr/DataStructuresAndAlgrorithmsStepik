using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class DynamicArray<T> where T : IComparable<T>
    {
        private T[] _array;

        private byte _increaseArraySizeBy = 2;
        private byte _defaultArraySizeWhenEmpty = 4;

        private int _size = 0;
        public int GetCount => _size;

        public DynamicArray()
        {
            _array = new T[0];
        }
        public DynamicArray(int length)
        {
            _array = new T[length];
        }

        public T this[int index]
        {
            get 
            {
                return Get(index);
            }
            set 
            {
                Insert(value, index);
            }
        }

        public string GetArrayStringToPrint()
        {
            string result = String.Empty;
            for (int i = 0; i < _size; i++)
                result += _array[i] + " ";
            return result;
        }

        public T Get(int index)
        {
            ThrowExceptionIfIndexValueIsCorrect(index);
            return _array[index];
        }

        public int Find(T key)
        {
            for (int i = 0; i < _size; i++)
            {
                if (key.CompareTo(_array[i]) == 0) // key == _array[i]
                    return i;
            }
            return -1;
        }

        public void PushBack(T item)
        {
            if (_size == _array.Length)
                IncreaseArraySize();
            _array[_size] = item;
            _size++;
        }

        public void PushFront(T item)
        {
            Insert(item, 0);
        }

        public void PopBack()
        {
            ThrowExceptionIfSizeIsZero();
            _size--;
        }

        public void RemoveByIndex(int index)
        {
            ThrowExceptionIfSizeIsZero();
            ThrowExceptionIfIndexValueIsCorrect(index);
            for (int i = index + 1; i < _size; i++)
            {
                _array[i - 1] = _array[i];
            }
            _size--;
        }

        public void PopFront()
        {
            RemoveByIndex(0);
        }

        public void Insert(T item, int index)
        {
            IncreaseArraySizeIfFull();
            ThrowExceptionIfIndexValueIsCorrect(index);
            for (int i = _size - 1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[index] = item;
            _size++;
        }

        private void IncreaseArraySizeIfFull()
        {
            if (_size == _array.Length)
                IncreaseArraySize();
        }

        private void IncreaseArraySize()
        {
            int newSize = _size * _increaseArraySizeBy;
            if (_size == 0)
                newSize = _defaultArraySizeWhenEmpty;
            var newArray = new T[newSize];
            for (int i = 0; i < _size; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }

        private void ThrowExceptionIfIndexValueIsCorrect(int index)
        {
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException("Index must be bigger than 0 and smaller than size!");
        }
        
        private void ThrowExceptionIfSizeIsZero()
        {
            if (_size == 0)
                throw new ArgumentException("There is nothing to delete, size is zero!");
        }
    }
}
