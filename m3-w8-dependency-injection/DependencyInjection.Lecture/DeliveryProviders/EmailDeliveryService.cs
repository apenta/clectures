using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Lecture.DeliveryProviders
{
    public class EmailDeliveryService : IDeliveryService
    {
        public void Send(string recipient, string message)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("josh.tucholski@gmail.com");
            msg.To.Add(recipient);
            msg.Subject = "An important message from C# " + DateTime.Now.ToString();
            msg.Body = message;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            #region Credentials
            client.Credentials = new NetworkCredential("email@email.com", "password");
            #endregion
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                msg.Dispose();
            }

        }
    }
}
