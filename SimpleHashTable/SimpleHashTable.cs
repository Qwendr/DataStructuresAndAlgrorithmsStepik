using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHashTable
{
    public class SimpleHashTable
    {
        private const byte _n = 117;
        private List<Item>[] _hashTable;

        public SimpleHashTable()
        {
            _hashTable  = new List<Item>[_n];
            for (int i = 0; i < _n; i++)
            {
                _hashTable[i] = new List<Item>();
            }
        }

        public void Add(int key, int value) 
        {
            int hashCode = GetHashCode(key);
            Item newItem = new Item(key, value);
            List<Item> itemsWithSameHashCode = _hashTable[hashCode];
            foreach (Item item in itemsWithSameHashCode) 
            {
                if (item.Key == key)
                    ThrowExceptionIfKeyExists(key);
            }
            itemsWithSameHashCode.Add(newItem);
        }
        // Тут возможна ошибка
        public void Delete(int key)
        {
            int hashCode = GetHashCode(key);
            List<Item> itemsWithSameHashCode = _hashTable[hashCode];
            foreach (Item item in itemsWithSameHashCode)
            {
                if(item.Key == key)
                {
                    itemsWithSameHashCode.Remove(item);
                    return;
                }

            }
        }
        public int Search(int key)
        {
            int hashCode = GetHashCode(key);
            foreach (Item item in _hashTable[hashCode])
            {
                if(item.Key == key)
                    return item.Value;
            }
            throw new ArgumentException($"There is no key {key} in table!");
        }

        private int GetHashCode(int key)
        {
            return key % _n;
        }

        private void ThrowExceptionIfKeyExists(int key)
        {
            throw new ArgumentException($"Key {key} already exists!");
        }
    }
}
