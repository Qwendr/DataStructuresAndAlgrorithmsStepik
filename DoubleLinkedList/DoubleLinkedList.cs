using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        private Node<T> _head;

        private int _count;
        public int Count => _count;

        public string GetListStringToPrint()
        {
            string result = String.Empty;
            Node<T> current = _head;
            while (current != null)
            {
                result += current.Value + " ";
                current = current.Next;
            }
            return result;
        }

        public Node<T> Find(T value)
        {
            if (_count == 0)
                return null;
            Node<T> current = _head;
            while (current.Value.CompareTo(value) != 0)
            {
                current = current.Next;
                if (current == null)
                {
                    return null;
                }
            }
            return current;
        }
        private Node<T> FindTail()
        {
            if (_count == 0)
                return null;
            var current = _head;
            while (current.Next != null) 
            {
                current = current.Next;
            }
            return current;
        }

        public void PushBack(T value)
        {
            var node = new Node<T>(value);
            if (_count == 0)
                _head = node;
            else
            {
                var tail = FindTail();
                tail.Next = node;
                node.Previous = tail;
            }
            _count++;
        }
        public void PushFront(T value)
        {
            var node = new Node<T>(value);
            if (_count != 0)
            {
                _head.Previous = node;
                node.Next = _head;
            }
            _head = node;
            _count++;
        }
        public void InsertBefore(Node<T> node, T value)
        {
            if (node == null)
                return;
            if (_count == 0)
            {
                PushFront(value);
                return;
            }
            var newNode = new Node<T>(value);

            newNode.Next = node;
            newNode.Previous = node.Previous;

            node.Previous.Next = newNode;
            node.Previous = newNode;

            _count++;
        }

        public void RemoveFirst()
        {
            ThrowExceptionIfCountZero();

            _head = _head.Next;
            if (_head != null)
                _head.Previous = null;
            _count--;
        }
        public void RemoveLast()
        {
            ThrowExceptionIfCountZero();
            if (_count == 1)
                _head = null;
            else
            {
                var current = _head;
                while (current.Next.Next != null)
                    current = current.Next;
                current.Next = null;
            }
            _count--;
        }
        public void RemoveNode(Node<T> node)
        {
            ThrowExceptionIfCountZero();
            if (_head == node)
            {
                RemoveFirst();
                return;
            }
            var previous = node.Previous;
            previous.Next = node.Next;
            if(previous.Next != null)
                node.Next.Previous = previous;
            _count--;
        }

        private void ThrowExceptionIfCountZero()
        {
            if (_count == 0)
                throw new Exception("List is empty!");
        }
    }
}
