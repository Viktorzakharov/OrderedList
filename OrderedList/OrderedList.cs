using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        public bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(string)) result = string.Compare(v1.ToString().Trim(), v2.ToString().Trim());
            else if (Convert.ToDouble(v1) < Convert.ToDouble(v2)) result = -1;
            else if (Convert.ToDouble(v1) == Convert.ToDouble(v2)) result = 0;
            else result = 1;
            return result;
        }

        public void Add(T value)
        {
            if (PreAdd(value, _ascending)) return;
            if (_ascending) InsertAfter(new Node<T>(value), GetAfterNodeAscending(value));
            else InsertAfter(new Node<T>(value), GetAfterNodeNotAscending(value));
        }

        public Node<T> Find(T val)
        {
            if (head == null) return null;
            if (_ascending && (Compare(val, head.value) == -1 || Compare(val, tail.value) == 1)) return null;
            if (!_ascending && (Compare(val, head.value) == 1 || Compare(val, tail.value) == -1)) return null;

            var node = head;
            while (node != null)
            {
                if (val.Equals(node.value)) return node;
                node = node.next;
            }
            return null;
        }

        public void Delete(T val)
        {
            var node = Find(val);
            if (node == null) return;
            if (node.Equals(head))
            {
                if (head.Equals(tail)) Clear(_ascending);
                else
                {
                    head = head.next;
                    head.prev = null;
                }
            }
            else if (node.Equals(tail))
            {
                node.prev.next = null;
                tail = node.prev;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
        }

        public void Clear(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Count()
        {
            var count = 0;
            var node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        public List<Node<T>> GetAll()
        {
            var r = new List<Node<T>>();
            var node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }

        private void AddInHead(Node<T> node)
        {
            if (head != null)
            {
                node.prev = null;
                node.next = head;
                head.prev = node;
                head = node;
            }
            else AddInTail(node);
        }

        private void AddInTail(Node<T> node)
        {
            if (head == null)
            {
                head = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
                node.next = null;
            }
            tail = node;
        }

        private void InsertAfter(Node<T> nodeToInsert, Node<T> nodeAfter)
        {
            if (nodeAfter == null) return;
            nodeToInsert.next = nodeAfter.next;
            nodeToInsert.prev = nodeAfter;
            nodeAfter.next.prev = nodeToInsert;
            nodeAfter.next = nodeToInsert;
        }

        private bool PreAdd(T value, bool increase)
        {
            var node = new Node<T>(value);
            if (head == null) AddInTail(node);
            else if ((Compare(value, head.value) != 1 && increase) || (Compare(value, head.value) != -1 && !increase)) AddInHead(node);
            else if ((Compare(value, tail.value) == 1 && increase) || (Compare(value, tail.value) == -1 && !increase)) AddInTail(node);
            else return false;
            return true;
        }

        private Node<T> GetAfterNodeAscending(T value)
        {
            var node = head;
            while (node != null)
            {
                if (Compare(value, node.value) != 1) return node.prev;
                node = node.next;
            }
            return null;
        }

        private Node<T> GetAfterNodeNotAscending(T value)
        {
            var node = head;
            while (node != null)
            {
                if (Compare(value, node.value) != -1) return node.prev;
                node = node.next;
            }
            return null;
        }
    }
}
