using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SetOnArray
{
    public class SetOnArray<T> where T : IComparable<T>
    {
        public List<T> Set { get; }

        public bool IsEmpty => Set.Count == 0;

        public SetOnArray()
        {
            Set = new List<T>();
        }

        public string Print()
        {
            string result = string.Empty;
            foreach (T item in Set) 
            {
                result += item + " ";
            }
            return result;
        }

        public bool Add(T value)
        {
            if(!Contains(value))
            {
                Set.Add(value);
                return true;
            }
            return false;
        }
        public bool Remove(T value) 
        {
            return Set.Remove(value);
        }

        public void Union(SetOnArray<T> otherSet)
        {
            ThrowExceptionIfEmptySet(otherSet);
            foreach (T value in otherSet.Set)
            {
                Add(value);
            }
        }
        public void Intersect(SetOnArray<T> otherSet)
        {
            ThrowExceptionIfEmptySet(otherSet);
            List<T> valuesToRemove = new List<T>();
            foreach (T value in Set)
            {
                if(!otherSet.Contains(value))
                    valuesToRemove.Add(value);
            }
            foreach (T value in valuesToRemove)
            {
                Remove(value);
            }
        }
        public void Difference(SetOnArray<T> otherSet)
        {
            ThrowExceptionIfEmptySet(otherSet);
            foreach(T value in otherSet.Set)
            {
                Remove(value);
            }
        }
        public bool IsSubsetOf(SetOnArray<T> otherSet)
        {
            bool isSubset = true;
            foreach (T value in Set)
            {
                isSubset = otherSet.Contains(value);
                if (!isSubset)
                    return isSubset;
            }
            return isSubset;
        }

        private bool Contains(T value)
        {
            return Set.Contains(value);
        }
        private void ThrowExceptionIfEmptySet(SetOnArray<T> otherSet)
        {
            if (otherSet == null)
                throw new ArgumentNullException($"Set {nameof(otherSet)} is empty!");
        }
    }
}
