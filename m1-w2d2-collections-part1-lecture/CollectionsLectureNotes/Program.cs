using CollectionsLectureNotes.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            ListExample.ShowListCode();

            

            // Let's start with an array
            int[] nums = new int[3] { 1, 10, 100 };

            // How do we add a number to this array?
            // - We just did this on the board


            // Creating a Brand New Instance of a List
            List<string> names = new List<string>();

            // Add strings to our list
            names.Add("Rob");
            names.Add("Jason");
            names.Add("Shane");
            names.Add("Jimmy");
            names.Add("Anna");

            //names.AddRange("Mike", "John", "Craig"); <-- wants a collection
            names.AddRange(new List<string>() { "Mike", "John", "Craig" }); //<-- inline declaration of list, passed to the method

            List<string> backRow = new List<string>();
            backRow.Add("Robert");
            backRow.Add("John");
            backRow.Add("Kathy");

            names.AddRange(backRow);        // this adds the contents of the backRow list to the names list
            

            // We can loop through a list just like an array
            for(int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }


            // FOREACH Loops allow us to start at the beginning of a collection and 
            // iterate through one item at a time, until the end.
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }




            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Finding all Johns");

            // Create a list that holds all of the indexes where John is located
            List<int> indexList = new List<int>();

            // Loop through the list, and if the value is equal to John, add the index to my indexlist
            for(int i = 0; i < names.Count; i++)
            {
                if (names[i] == "John")
                {
                    indexList.Add(i);
                }
            }

            // At the end of the loop, indexList should only hold positions where John is found
            foreach (int index in indexList)
            {
                Console.WriteLine($"John is found in position {index}");
            }


            // Creating a Stack
            Stack<string> inbox = new Stack<string>();
            inbox.Push("Schedule 1:1");
            inbox.Push("Push exercises");
            inbox.Push("Practice elevator pitch");

            string firstTask = inbox.Pop();
            Console.WriteLine($"The first task is {firstTask}");

            // Empty the stack
            while (inbox.Count > 0)
            {
                Console.WriteLine($"The next task is {inbox.Pop()}");
            }


            

        }
    }
}
