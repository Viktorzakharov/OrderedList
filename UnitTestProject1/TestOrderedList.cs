using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace UnitTestProject1
{
    [TestClass]
    public class TestOrderedList
    {
        private static OrderedList<int> listNoneAsc = new OrderedList<int>(false);
        private static OrderedList<int> listNoneNotAsc = new OrderedList<int>(true);
        private static OrderedList<int> list = GenerateList(new OrderedList<int>(true), 7);

        [TestMethod]
        public void TestDeleteNone()
        {
            Assert.AreEqual(0, listNoneAsc.Count());
            Assert.AreEqual(0, listNoneNotAsc.Count());
            listNoneAsc.Delete(5);
            listNoneNotAsc.Delete(5);
            Assert.AreEqual(0, listNoneAsc.Count());
            Assert.AreEqual(0, listNoneNotAsc.Count());
        }

        [TestMethod]
        public void TestFindNone()
        {
            Assert.AreEqual(0, listNoneAsc.Count());
            Assert.AreEqual(0, listNoneNotAsc.Count());
            Assert.IsNull(listNoneAsc.Find(5));
            Assert.IsNull(listNoneNotAsc.Find(5));
            Assert.AreEqual(0, listNoneAsc.Count());
            Assert.AreEqual(0, listNoneNotAsc.Count());
        }

        [TestMethod]
        public void TestAddNone()
        {
            Assert.AreEqual(0, listNoneAsc.Count());
            Assert.AreEqual(0, listNoneNotAsc.Count());
            listNoneAsc.Add(5);
            listNoneNotAsc.Add(5);
            Assert.AreEqual(1, listNoneAsc.Count());
            Assert.AreEqual(1, listNoneNotAsc.Count());
            Assert.AreEqual(5, listNoneAsc.Find(5).value);
            Assert.AreEqual(5, listNoneNotAsc.Find(5).value);
            Assert.AreEqual(listNoneAsc.head, listNoneAsc.Find(5));
            Assert.AreEqual(listNoneNotAsc.head, listNoneNotAsc.Find(5));
            Assert.AreEqual(listNoneAsc.tail, listNoneAsc.Find(5));
            Assert.AreEqual(listNoneNotAsc.tail, listNoneNotAsc.Find(5));
        }

        [TestMethod]
        public void TestAdd()
        {
            var startLength = list.Count();
            var prev = list.head.next.next.next;
            var next = list.head.next.next.next.next;
            if (Math.Abs(next.value - prev.value) == 0)
            {
                next = prev;
                prev = next.prev;
            }
            list.Add(next.value);
            Assert.AreEqual(startLength + 1, list.Count());
            var node = list.Find(next.value);
            Assert.AreEqual(prev.value, node.prev.value);
            Assert.AreEqual(next.value, node.next.value);
        }

        [TestMethod]
        public void TestFind()
        {
            var list1 = new OrderedList<int>(true);
            list1.Add(1);
            list1.Add(4);
            list1.Add(5);
            Assert.IsNull(list1.Find(3));
            Assert.IsNull(list1.Find(6));
            Assert.IsNull(list1.Find(0));
            Assert.AreEqual(list1.tail.prev, list1.Find(4));
        }

        [TestMethod]
        public void TestDelete()
        {
            var list1 = new OrderedList<int>(false);
            list1.Add(1);
            list1.Add(2);
            list1.Add(4);
            var startCount = list1.Count();
            list1.Delete(0);
            Assert.AreEqual(startCount, list1.Count());
            list1.Delete(6);
            Assert.AreEqual(startCount, list1.Count());
            list1.Delete(3);
            Assert.AreEqual(startCount, list1.Count());
            list1.Delete(2);
            Assert.AreEqual(startCount - 1, list1.Count());
            Assert.IsNull(list1.Find(2));
        }

        [TestMethod]
        public void TestClear()
        {
            var asc = true;
            list.Clear(asc);
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
            Assert.AreEqual(asc, list._ascending);
        }

        private static OrderedList<int> GenerateList(OrderedList<int> list, int count)
        {
            var random = new Random();
            for (int i = 0; i < count; i++)
                list.Add(random.Next(255));
            return list;
        }
    }
}
