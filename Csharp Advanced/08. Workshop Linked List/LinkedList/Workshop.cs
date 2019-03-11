using System;
using System.Linq;
using System.Collections.Generic;


namespace LinkedList
{
   public class Workshop
    {
      public static void Main(string[] args)
        {
            CoolStack stack = new CoolStack();

            stack.Push(6);
            stack.Push(9);
            stack.Push(10);

            var linkedList = new CoolLinkedList();

            linkedList.AddHead(5);
            linkedList.AddHead(10);
            linkedList.AddHead(15);

            Console.WriteLine((int)linkedList.Head.Value == 15);
            Console.WriteLine((int)linkedList.Tail.Value == 5);
            Console.WriteLine(linkedList.Count == 3);

            linkedList.AddTail(20);
            linkedList.AddTail(25);

            linkedList.ForEach(Console.WriteLine);

            Console.WriteLine((int)linkedList.Head.Value == 15);
            Console.WriteLine((int)linkedList.Tail.Value == 25);
            Console.WriteLine(linkedList.Count == 5);

            Console.WriteLine((int)linkedList.RemoveHead() == 15);
            Console.WriteLine((int)linkedList.RemoveHead() == 10);
            Console.WriteLine((int)linkedList.Head.Value == 5);
            Console.WriteLine(linkedList.Count == 3);

            var arr = linkedList.ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
