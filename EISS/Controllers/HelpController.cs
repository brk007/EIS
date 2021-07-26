using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace EIS.Controllers
{
    public class HelpController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string mail, string text,string subject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test", mail));
            message.To.Add(new MailboxAddress("Burak", "burak@gmail.com"));
            message.Subject = (subject);
            message.Body = new TextPart("plain")
            {
                Text = text
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(mail, "password");

                client.Send(message);
                client.Disconnect(true);
            }
            return RedirectToAction("SendMessage", "Help");
        }
    }
}
