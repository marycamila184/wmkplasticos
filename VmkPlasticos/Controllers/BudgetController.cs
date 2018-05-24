using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using VmkPlasticos.Models;

namespace VmkPlasticos.Controllers
{
    public class BudgetController : Controller
    {
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
        public ActionResult SendBudget(BudgetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Linha.Equals(""))
                    {
                        return RedirectToAction("Index", new { message = "Ocorreu um erro ao enviar seu orçamento! Por favor selecione uma linha de produtos." });
                    }

                    if (model.Products.Count < 1)
                    {
                        return RedirectToAction("Index", new { message = "Ocorreu um erro ao enviar seu orçamento! Por favor selecione ao menos um produto para orçamento." });
                    }

                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

                    var mail = new MailMessage();
                    mail.From = new MailAddress("kaembalagens@outlook.com");
                    mail.To.Add("kaembalagens@outlook.com");
                    mail.Subject = "Novo orçamento do Site";
                    mail.IsBodyHtml = true;
                    string htmlBody;
                    htmlBody = "<p> Nome: " + model.Nome + " </p> <p> Telefone: " + model.Telefone + "</p> <p> Email: " + model.Email + "</p> <p> Linha: " + model.Linha + "</p>";
                    htmlBody += "<p> Produtos Solicitados: </p>";
                    htmlBody += "<p><table border='1'><thead><tr><th>Nome</th><th>Quantidade</th></tr></thead><tbody>";
                    foreach (var item in model.Products)
                    {
                        htmlBody += "<tr><td>" + item.NomeProduto + "</td><td>" + item.Quantidade + " " + item.Unidades + "</td></tr>";
                    }
                    htmlBody += "</tbody></table></p>";
                    mail.Body = htmlBody;
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("kaembalagens@outlook.com", "Kaindustria2035");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);

                    return RedirectToAction("Index", new { message = "Seu orçamento foi enviado com sucesso! Em até 48 horas entraremos em contato." });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", new { message = "Ocorreu um erro ao enviar seu orçamento! Por favor tente novamente mais tarde." });
                }
            }
            else
            {
                return View("~/Views/Budget/Index.cshtml", model);
            }
        }
    }
}