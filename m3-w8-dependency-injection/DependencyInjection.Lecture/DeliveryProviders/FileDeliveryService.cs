using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;             // Need to add a using statement


namespace DependencyInjection.Lecture.DeliveryProviders
{
    public class FileDeliveryService : IDeliveryService
    {
        public void Send(string recipient, string message)
        {
            // need a try-catch
            try
            {
                // Need the file path
                string filename = "messages.txt";
                string directory = Directory.GetCurrentDirectory();
                string fullpath = Path.Combine(directory, filename);

                // StreamWriter to append/write a line to a file
                using (StreamWriter sw = new StreamWriter(fullpath, true))
                {
                    sw.WriteLine("----------------");
                    sw.WriteLine($"DATE: {DateTime.Now}");
                    sw.WriteLine($"TO: {recipient}");
                    sw.WriteLine($"MESSAGE: {message}");
                }                
            }
            catch(IOException ex)
            {
                Console.WriteLine("ERROR SAVING TO FILE");
            }

        }
    }
}
