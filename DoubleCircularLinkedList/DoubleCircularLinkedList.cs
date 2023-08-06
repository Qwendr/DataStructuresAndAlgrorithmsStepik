using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCircularLinkedList
{
    public class DoubleCircularLinkedList<T> where T : IComparable<T>
    {
        private Node<T> _head;

        private int _count;
        public int Count => _count;

        public string GetListStringToPrint(bool forward)
        {
            if(_count == 0)
                return String.Empty;
            if (forward)
                return GetListStringToPrint(_head, forward);
            return GetListStringToPrint(_head.Previous, forward);
        }
        public string GetListStringToPrint(Node<T> node, bool forward)
        {
            if (_count == 0)
                return String.Empty;
            string result = String.Empty;
            var current = node;
            do
            {
                result += current.Value + " ";
                if (forward)
                    current = current.Next;
                else
                    current = current.Previous;
            } while (current != node);
            return result;
        }

        public Node<T> Find(T value)
        {
            if (_count == 0)
                return null;
            var current = _head;
            do
            {
                if(value.CompareTo(current.Value) == 0)
                    return current;
                current = current.Next;
            } while(current != _head);
            return null;
        }

        public void PushFront(T value)
        {
            var nodeNew = new Node<T>(value);
            PushBack(nodeNew, value);
            _head = nodeNew;
        }
        public void PushBack(T value)
        {
            var nodeNew = new Node<T>(value);
            PushBack(nodeNew, value);
        }
        private void PushBack(Node<T> node, T value)
        {
            if (_count == 0)
                InsertNodeToEmptyList(node);
            else
                InsertBeforeSpecified(_head, node);
        }

        public void RemoveFirst()
        {
            RemoveNode(_head);
        }
        public void RemoveNode(Node<T> node)
        {
            ThrowExceptionIfCountIsZero();
            if (_count == 1 && _head == node)
                _head = null;
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                if (_head == node)
                    _head = node.Next;
            }
            _count--;
        }
        public void RemoveLast()
        {
            ThrowExceptionIfCountIsZero();
            RemoveNode(_head.Previous);
        }

        public void InsertBefore(Node<T> node, T value)
        {
            var nodeNew = new Node<T>(value);
            InsertBeforeSpecified(node, nodeNew);
            if(node == _head)
                _head = nodeNew;
        }
        private void InsertBeforeSpecified(Node<T> nodeBefore, Node<T> nodeSpecified)
        {
            nodeSpecified.Next = nodeBefore;
            nodeSpecified.Previous = nodeBefore.Previous;

            nodeBefore.Previous.Next = nodeSpecified;
            nodeBefore.Previous = nodeSpecified;

            _count++;
        }
        // В пустом списке next и previous указывают на себя
        private void InsertNodeToEmptyList(Node<T> node)
        {
            node.Next = node;
            node.Previous = node;
            _head = node;
            _count++;
        }

        private void ThrowExceptionIfCountIsZero()
        {
            if (_count == 0)
                throw new Exception("List is empty!");
        }
    }
}
