using System;

namespace OrderedList
{
    public class OrderList
    {
        public Node head;
        public Node tail;
        public int length;
        public bool increase;

        public OrderList(bool item)
        {
            head = null;
            tail = null;
            length = 0;
            increase = item;
        }

        public void AddNode(object value)
        {
            if (PreviouslyCheck(value, increase)) return;
            var virtNode = GetVirtNode(increase);

            while (true)
            {
                if (BiggerElement(value, virtNode.value))
                {
                    if (increase) AddNodeAfterNode(new Node(value), virtNode);
                    else AddNodeAfterNode(new Node(value), virtNode.next);
                    break;
                }
                else
                {
                    if (increase) virtNode = virtNode.prev;
                    else
                    {
                        Node hNode = new Node(virtNode.prev.value);
                        hNode.next = virtNode.next.next;
                        hNode.prev = virtNode.prev.next;
                        virtNode = hNode;
                    }
                }
            }
        }

        public Node Find(object value)
        {
            if (increase && (BiggerElement(head.value,value) || BiggerElement(value, tail.value)))
                return null;
            else if (!increase && (BiggerElement(value, head.value) || BiggerElement(tail.value,value)))
                return null;

            var node = head;
            while (node != null)
            {
                if (Equals(node.value, value)) return node;
                node = node.next;
            }
            return null;
        }

        public void DeleteOnceItem(object value)
        {
            var node = Find(value);
            if (node != null)
            {
                if (node == head)
                {
                    node.next.prev = null;
                    head = node.next;
                }
                else if (node == tail)
                {
                    node.prev.next = null;
                    tail = node.prev;
                }
                else
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                }
                length--;
            }
            else Console.WriteLine("Элемента с заданным значением нет в списке!");
        }

        public virtual bool BiggerElement(object a, object b)
        {
            if ((int)a > (int)b) return true;
            else return false;
        }

        private void AddInHead(Node node)
        {
            if (head != null)
            {
                node.prev = null;
                node.next = head;
                head.prev = node;
                head = node;
                length++;
            }
            else AddInTail(node);
        }

        private void AddInTail(Node node)
        {
            if (head != null)
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
            }
            else
            {
                head = node;
                tail = node;
            }
            length++;
        }

        private void AddNodeAfterNode(Node node, Node nodeAfter)
        {
            node.next = nodeAfter.next;
            node.prev = nodeAfter;
            nodeAfter.next.prev = node;
            nodeAfter.next = node;
            length++;
        }

        private bool PreviouslyCheck(object value, bool increase)
        {
            var node = new Node(value);

            if (head == null)
            {
                AddInTail(node);
                return true;
            }

            if ((!BiggerElement(value, head.value) && increase) ||
                (BiggerElement(value, head.value) && !increase))
            {
                AddInHead(node);
                return true;
            }
            else if ((BiggerElement(value, tail.value) && increase) ||
                (!BiggerElement(value, tail.value) && !increase))
            {
                AddInTail(node);
                return true;
            }
            return false;
        }

        private Node GetVirtNode(bool increase)
        {
            if (increase) return tail.prev;
            else
            {
                var node = new Node(head.next.value);
                node.next = head;
                node.prev = head.next.next;
                return node;
            }
        }
    }
}
