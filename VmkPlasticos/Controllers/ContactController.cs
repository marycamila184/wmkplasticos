using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using VmkPlasticos.Models;

namespace VmkPlasticos.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(string message = null)
        {
            if (message != null)
            {
                if (message.Contains("erro"))
                {
                    ViewBag.MessageError = message;
                    ViewBag.MessageSuccess = null;
                }
                else
                {
                    ViewBag.MessageSuccess = message;
                    ViewBag.MessageError = null;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult SendEmailContact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

                    var mail = new MailMessage();
                    mail.From = new MailAddress("kaembalagens@outlook.com");
                    mail.To.Add("kaembalagens@outlook.com");
                    mail.Subject = "Mensagem de contato do site";
                    mail.IsBodyHtml = true;
                    string htmlBody;
                    htmlBody = "<p> Nome: " + model.Nome + " </p> <p> Telefone: " + model.Telefone + "</p> <p> Email: " + model.Email + "</p> <p> Assunto: " + model.Assunto + "</p> <p> Mensagem: " + model.Mensagem + "</p>";
                    mail.Body = htmlBody;
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("kaembalagens@outlook.com", "Kaindustria2035");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);

                    return RedirectToAction("Index", new { message = "Sua mensagem foi enviada com sucesso! Em breve entraremos em contato." });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", new { message = "Ocorreu um erro ao enviar sua mensagem! Por favor tente novamente mais tarde." });
                }
            }
            else
            {
                return View("~/Views/Contact/Index.cshtml", model);
            }
        }
    }
}