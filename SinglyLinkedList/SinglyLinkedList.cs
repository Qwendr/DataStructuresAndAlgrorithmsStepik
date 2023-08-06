using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T> where T : IComparable<T>
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
            Node<T> current = _head;
            while (current.Next != null) 
                current = current.Next;
            return current;
        }

        public void PushFront(T value)
        {
            Node<T> node = new Node<T>(value);
            if(_count != 0)
                node.Next = _head;
            _head = node;
            _count++;
        }

        public void PushBack(T value)
        {
            Node<T> node = new Node<T>(value);
            if (_count == 0)
                _head = node;
            else
            {
                Node<T> tail = FindTail();
                tail.Next = node;
            }
            _count++; 
        }

        public void InsertAfter(Node<T> node, T value)
        {
            if (node == null)
                return;
            Node<T> newNode = new Node<T>(value);
            newNode.Next = node.Next;
            node.Next = newNode;

            _count++;
        }

        public void RemoveFirst()
        {
            ThrowExceptionIfCountZero();

            _head = _head.Next;
            _count--;
        }

        public void RemoveLast()
        {
            ThrowExceptionIfCountZero();

            if (_count == 1)
                _head = null;
            else
            {
                Node<T> current = _head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            _count--;
        }

        public void RemoveNode(Node<T> node)
        {
            ThrowExceptionIfCountZero();
            if (_head == node)
                _head = node.Next;
            else
            {
                Node<T> current = _head;
                while(current.Next != null)
                {
                    if (current.Next == node)
                        break;
                    current = current.Next;
                }
                current.Next = node.Next;
            }
            _count--;
        }
        
        private void ThrowExceptionIfCountZero()
        {
            if (_count == 0)
                throw new Exception("List is empty!");
        }
    }
}
