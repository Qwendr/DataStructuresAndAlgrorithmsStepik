using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHashTable
{
    public class Item
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Item(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}
