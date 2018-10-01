using System;

namespace OrderedList
{
    public class Test
    {
        public static void DeleteOnceItem(OrderList list, object value) //Тест. Удаление одного элемента по значению
        {
            var startLength = list.length;
            var node = list.Find(value);

            var countStart = HelpFind(list, value);
            Write(list);
            list.DeleteOnceItem(value);
            Write(list);
            var countEnd = HelpFind(list, value);

            if (node != null)
            {
                if (list.length == startLength - 1 && countEnd == countStart - 1)
                    Console.WriteLine("Удаление узла прошло верно!\n");
                else Console.WriteLine("Удаление узла прошло НЕВЕРНО!\n");
            }
            else
            {
                if (startLength == list.length) Console.WriteLine("Метод отработал верно!");
                else Console.WriteLine("Метод отработал НЕВЕРНО!");
            }
        }

        public static void AddNode(OrderList list, object value) // Тест. Добавление узла после заданного узла
        {
            var startLength = list.length;

            var countStart = HelpFind(list, value);
            Write(list);
            list.AddNode(value);
            Write(list);
            var countEnd = HelpFind(list, value);

            if (list.length == startLength + 1 && countEnd == countStart + 1)
                Console.WriteLine("Добавление узла прошло верно!\n");
            else Console.WriteLine("Добавление узла прошло НЕВЕРНО!\n");
        }

        public static void Find(OrderList list, object value)
        {
            Write(list);
            var result = list.Find(value);

            try { Console.WriteLine(result.value + "\n"); }
            catch (NullReferenceException) { Console.WriteLine("Элемента с заданным значением нет в списке!\n"); }

            if (result != null)
            {
                if (HelpFind(list, value) >= 1) Console.WriteLine("Поиск узла прошел верно!\n");
                else Console.WriteLine("Поиск узла прошел НЕВЕРНО!\n");
            }
            else
            {
                if (HelpFind(list, value) == 0) Console.WriteLine("Поиск узла прошел верно!\n");
                else Console.WriteLine("Поиск узла прошел НЕВЕРНО!\n");
            }
        }

        public static int HelpFind(OrderList list, object value)
        {
            var node = list.head;
            var count = 0;
            while (node != null)
            {
                if (Equals(node.value, value)) count++;
                node = node.next;
            }
            return count;
        }

        public static void Write(OrderList list)
        {
            var step = list.head;
            while (step != null)
            {
                Console.Write(step.value + " ");
                step = step.next;
            }
            Console.WriteLine("Количество {0}\n", list.length);
        }
    }
}
