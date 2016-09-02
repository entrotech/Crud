using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Crud.Web.Services
{
    public class NotificationService
    {
        public async Task SendEmail(string fromAddress, string[] toAddresses, string subject, string htmlMessage, string textMessage)
        {
            SendGridAPIClient sg = new SendGridAPIClient("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");
            Email from = new Email(fromAddress);
            Email to = new Email(String.Join(";", toAddresses));
            Content content = new Content("text/plain", textMessage);
            Mail mail = new Mail(from, subject, to, content);

            var response = await sg.client.mail.send.post(requestBody: mail.Get());

            //SendGridMessage message = new SendGridMessage();
            //message.From = fromAddress;
            //foreach(string toAddr in toAddresses)
            //{
            //    message.AddTo(toAddr);
            //}
            //message.Subject = subject;
            //message.Html = htmlMessage;
            //message.Text = textMessage;

            //SendGrid.Web transportWeb = new SendGrid.Web("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");
            //await transportWeb.DeliverAsync(message);

        }
    }
}