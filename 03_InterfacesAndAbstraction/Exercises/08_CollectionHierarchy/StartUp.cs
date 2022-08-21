using System;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Contracts;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int removeOperations = int.Parse(Console.ReadLine());

            AddToAnyCollection(addCollection, input);
            AddToAnyCollection(addRemoveCollection, input);
            AddToAnyCollection(myList, input);

            RemoveFromAnyCollection(addRemoveCollection, removeOperations);
            RemoveFromAnyCollection(myList, removeOperations);
        }

        private static void AddToAnyCollection(IAddCollection<string> collection, string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string element = input[i];

                Console.Write(collection.Add(element) + " ");
            }

            Console.WriteLine();
        }

        private static void RemoveFromAnyCollection(IAddRemoveCollection<string> collection, int removeOperations)
        {
            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}