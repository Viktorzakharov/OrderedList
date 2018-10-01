namespace OrderedList
{
    class StringOrderedList : OrderList
    {
        public StringOrderedList(bool item) : base(item) { }

        public override bool BiggerElement(object a, object b)
        {
            if (string.Compare((string)a, (string)b) > 0) return true;
            else return false;
        }
    }
}
