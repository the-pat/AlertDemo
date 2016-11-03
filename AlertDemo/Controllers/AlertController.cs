using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AlertDemo.Models;
using Twilio.TwiML;

namespace AlertDemo.Controllers
{
    public class AlertController : Controller
    {
        // GET: Alert
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MessageModel message)
        {
            if (ModelState.IsValid)
            {
                var smsService = new Services.SmsService();
                smsService.SendMessage(
                    WebConfigurationManager.AppSettings["TwilioSmsNumber"],
                    message.To,
                    message.Body
                );

                return View("Index");
            }

            return View(message);
        }
    }
}