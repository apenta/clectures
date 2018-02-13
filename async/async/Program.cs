using System.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Diagnostics;
using System.Data.SqlClient;

namespace async
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            // This code will download a series of images synchronously, one after the other.
            //SyncDownloads();

            Console.ReadLine();

            // This method will instruct the program to download the images asynchronously.
            // The method won't be able to finish until all images have been downloaded.                        
            //AsyncDownloads().Wait();
            
            MassiveAsyncDownloads().Wait();
        }

        /// <summary>
        /// We'll use the stopwatch to track how long this method takes to complete.
        /// </summary>
        private static void SyncDownloads()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ImageDownloader downloader = new ImageDownloader("sync");
            int i = 0;

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            i++;
            Console.WriteLine($"Downloading image {i}");
            downloader.DownloadRandomPhoto();

            sw.Stop();

            Console.WriteLine($"Downloaded {i} images in {sw.ElapsedMilliseconds}ms");
        }
        
        private async static Task MassiveAsyncDownloads()
        {
            List<Task> tasks = new List<Task>(); //all of the ongoing tasks
            ImageDownloader downloader = new ImageDownloader("lotsoffiles");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int i = 0;

            while (i < 100)
            {
                Console.WriteLine($"Downloading image {i}");
                tasks.Add(downloader.DownloadRandomPhotoAsync(i));

                i++;
            }

            Task.WaitAll(tasks.ToArray()); //wait for all tasks to complete before proceeding forward

            sw.Stop();
            Console.WriteLine($"Downloaded {i} images in {sw.ElapsedMilliseconds}ms");

        }


        /// <summary>
        /// We'll send the requests asynchronously but measure the time it takes on the stopwatch for all of them to complete.
        /// </summary>
        /// <returns>Task - so that our void main can wait for it to complete.</returns>
        private async static Task AsyncDownloads()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ImageDownloader downloader = new ImageDownloader("async");
            int i = 0;

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task1 = downloader.DownloadRandomPhotoAsync(i);
            
            i++;
            Console.WriteLine($"Downloading image {i}");
            var task2 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task3 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task4 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task5 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task6 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task7 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task8 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task9 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task10 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task11 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task12 = downloader.DownloadRandomPhotoAsync(i);

            i++;
            Console.WriteLine($"Downloading image {i}");
            var task13 = downloader.DownloadRandomPhotoAsync(i);

            await task1;
            await task2;
            await task3;
            await task4;
            await task5;
            await task6;
            await task7;
            await task8;
            await task9;
            await task10;
            await task11;
            await task12;
            await task13;

            sw.Stop();

            Console.WriteLine($"Downloaded {i} images in {sw.ElapsedMilliseconds}ms");
        }                
    }
}
