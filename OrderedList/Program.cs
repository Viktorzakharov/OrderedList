namespace OrderedList
{
    class Program
    {
        static void Main()
        {
            var list = new StringOrderedList(false);

            list.AddNode("aekr");
            list.AddNode("do");
            list.AddNode("jre");
            list.AddNode("kn");
            list.AddNode("oek");
            list.AddNode("pt");
            Test.AddNode(list, "cw");
            Test.DeleteOnceItem(list, "jre");
            Test.Find(list, "ggg");
        }
    }
}
