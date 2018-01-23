using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLectureNotes.Reference
{
    public  class QueueExample
    {
        public static void ShowQueueCode()
        {


            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.
            Queue<string> priorities = new Queue<string>();

            priorities.Enqueue("Clean the dishes");
            priorities.Enqueue("Wash the counters");
            priorities.Enqueue("Sweep the floor");
            priorities.Enqueue("Scrub the floor");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            while (priorities.Count > 0)
            {
                string nextPriority = priorities.Dequeue();
                Console.WriteLine("NEXT PRIORITY " + nextPriority);
            }

        }
    }
}
