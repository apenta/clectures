using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLectureNotes.Reference
{
    public class StackExample
    {
        public static void ShowStackCode()
        {


            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 
            Stack<string> browserStack = new Stack<string>();

            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            browserStack.Push("http://www.google.com");
            browserStack.Push("http://www.cnn.com");
            browserStack.Push("http://www.google.com");
            browserStack.Push("http://www.techelevator.com");
            browserStack.Push("http://www.si.com");

            ////////////////////
            // POPPING THE STACK
            ////////////////////
            while (browserStack.Count > 0)
            {
                string previousPage = browserStack.Pop();
                Console.WriteLine("PREVIOUS PAGE: " + previousPage);
            }
        }
    }
}
