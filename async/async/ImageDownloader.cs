using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace async
{
    public class ImageDownloader
    {
        private string folder;

        public ImageDownloader(string folder)
        {
            this.folder = folder;            
        }

        /// <summary>
        /// Downloads a random photo synchronously
        /// </summary>
        public void DownloadRandomPhoto()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            try
            {
                WebClient client = new WebClient();

                // DownloadFile takes two arguments, a URI and a final file name.
                client.DownloadFile(new Uri($"https://picsum.photos/800/1200/?random"), $"{folder}/{Guid.NewGuid()}.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return;
        }        




        /// <summary>
        /// Downloads a random image asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task DownloadRandomPhotoAsync(int i)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            try
            {
                WebClient client = new WebClient();

                // DownloadFileTaskAsync takes two arguments, a URI and a final file name.
                await client.DownloadFileTaskAsync(new Uri($"https://picsum.photos/800/1200/?random"), $"{folder}/{Guid.NewGuid()}.jpg");

                Console.WriteLine("Finished download - " + i );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return;
        }


        /// <summary>
        /// Downloads a random photo and gets the image file size synchronously
        /// </summary>
        /// <returns></returns>
        public int GetRandomPhotoSize()
        {
            try
            {
                WebClient client = new WebClient();

                // DownloadData takes one arguments, a URI
                byte[] file = client.DownloadData(new Uri($"https://picsum.photos/200/300/?random"));

                return file.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Downloads a random photo asynchronously and gets the image size.
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetRandomPhotoSizeAsync()
        {
            try
            {
                WebClient client = new WebClient();

                // DownloadData takes one arguments, a URI
                byte[] file = await client.DownloadDataTaskAsync(new Uri($"https://picsum.photos/200/300/?random"));

                return file.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
