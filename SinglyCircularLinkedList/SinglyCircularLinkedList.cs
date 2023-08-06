using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SinglyCircularLinkedList
{
    public class SinglyCircularLinkedList<T> where T : IComparable<T>
    {
        private Node<T> _tail;

        private int _count;
        public int Count => _count;

        public string GetListStringToPrint()
        {
            if (_count == 0)
                return String.Empty;
            return GetListStringToPrintStartFrom(_tail.Next);
        }
        public string GetListStringToPrintStartFrom(Node<T> node)
        {
            if (_count == 0)
                return String.Empty;
            string result = String.Empty;
            var current = node;
            do
            {
                result += current.Value + " ";
                current = current.Next;
            } while (current != node);
            return result;
        }

        public Node<T> Find(T value)
        {
            if (_count == 0)
                return null;
            var current = _tail;
            do
            {
                if (value.CompareTo(current.Value) == 0)
                    return current;
                current = current.Next;
            } while (current != _tail);
            return null;
        }

        public void PushBack(T value)
        {
            var node = new Node<T>(value);
            if (_count == 0)
                InsertNodeToEmptyList(node);
            else
            {
                InsertAfterSpecified(_tail, node);
                _tail = node;
            }
        }
        public void PushFront(T value)
        {
            var node = new Node<T>(value);
            if (_count == 0)
                InsertNodeToEmptyList(node);
            else
                InsertAfterSpecified(_tail, node);
        }
        public void InsertAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            InsertAfterSpecified(node, newNode);
            if (_tail == node)
                _tail = newNode;
        }

        private void InsertAfterSpecified(Node<T> nodeAfter, Node<T> nodeToInsert)
        {
            nodeToInsert.Next = nodeAfter.Next;
            nodeAfter.Next = nodeToInsert;
            _count++;
        }
        private void InsertNodeToEmptyList(Node<T> node)
        {
            node.Next = node;
            _tail = node;
            _count++;
        }

        public void RemoveFirst()
        {
            RemoveNodeAfterSpecified(_tail);
        }
        public void RemoveNode(Node<T> node)
        {
            ThrowExceptionIfCountIsZero();
            var current = node;
            while (current.Next != node) 
            {
                current = current.Next;
            }
            RemoveNodeAfterSpecified(current);
        }
        public void RemoveLast()
        {
            RemoveNode(_tail);
        }
        private void RemoveNodeAfterSpecified(Node<T> nodeAfter)
        {
            ThrowExceptionIfCountIsZero();
            if (_count == 1)
                _tail = null;
            else
            {
                if (nodeAfter.Next == _tail)
                    _tail = nodeAfter;
                nodeAfter.Next = nodeAfter.Next.Next;
            }
            _count--;
        }

        private void ThrowExceptionIfCountIsZero()
        {
            if (_count == 0)
                throw new Exception("List is empty!");
        }
    }
}
