using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedListWithTail
{
    public class SinglyLinkedListWithTail<T> where T : IComparable<T>
    {
       /*
         * 1. В пустом списке head и tale указывают в null.
         * 2. При наличии в списке одного элемента, оба указывают на него. 
       */
        private Node<T> _head;
        private Node<T> _tail;

        private int _count = 0;
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

        public void PushBack(T value)
        {
            var node = new Node<T>(value);
            if (_count == 0)
                _head = node;
            else
                _tail.Next = node;
            _tail = node;
            _count++;
        }

        public void PushFront(T value)
        {
            var node = new Node<T>(value);
            if (_count == 0)
                _tail = node;
            else
                node.Next = _head;
            _head = node;
            _count++;
        }

        public void InsertAfter(Node<T> node, T value)
        {
            if (node == null)
                return;
            var newNode = new Node<T>(value);
            newNode.Next = node.Next;
            node.Next = newNode;
            if (node == _tail)
                _tail = newNode;
            _count++;
        }

        public void RemoveFirst()
        {
            ThrowExceptionIfCountZero();
            if (_count == 1)
            {
                UpdateHeadAndTailToNull();
            }
            else
                _head = _head.Next;
            _count--;
        }

        public void RemoveLast()
        {
            ThrowExceptionIfCountZero();
            if (_count == 1)
            {
                UpdateHeadAndTailToNull();
            }
            else
            {
                var current = _head;
                while(current.Next != _tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                _tail = current;
            }
            _count--;
        }

        public void RemoveNode(Node<T> node)
        {
            if (_head == node)
                RemoveFirst();
            else if (_tail == node)
                RemoveLast();
            else
            {
                var current = _head;
                while (current != _tail)
                {
                    if (current.Next == node)
                        break;
                    current = current.Next;
                }
                current.Next = node.Next;
                _count--;
            }
        }

        private void UpdateHeadAndTailToNull()
        {
            _head = null;
            _tail = null;
        }
        private void ThrowExceptionIfCountZero()
        {
            if (_count == 0)
                throw new Exception("List is empty!");
        }
    }
}
