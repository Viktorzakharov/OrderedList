namespace OrderedList
{
    public class Node
    {
        public object value;
        public Node next;
        public Node prev;

        public Node(object Value)
        {
            value = Value;
            next = null;
            prev = null;
        }
    }
}
