using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main()
        {
            var list = new OrderedList<int>(true);
            list.Add(999);
            list.Add(999);
            list.Add(888);
            list.Add(777);
            list.Add(777);
            Write(list);
        }

        public static void Write(OrderedList<int> list)
        {
            var step = list.head;
            while (step != null)
            {
                Console.Write("{0} ", step.value);
                step = step.next;
            }
            Console.WriteLine("Количество {0}\n", list.Count());
        }

    }
}
