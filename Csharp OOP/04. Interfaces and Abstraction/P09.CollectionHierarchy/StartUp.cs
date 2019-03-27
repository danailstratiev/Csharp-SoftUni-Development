using System;

namespace P09.CollectionHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var input = Console.ReadLine().Split();
            var numberOfRemovals = int.Parse(Console.ReadLine());

            Console.WriteLine(addCollection.Add(input));
            Console.WriteLine(addRemoveCollection.Add(input));
            Console.WriteLine(myList.Add(input));
            Console.WriteLine(addRemoveCollection.Remove(numberOfRemovals));
            Console.WriteLine(myList.Remove(numberOfRemovals));
        }
    }
}
