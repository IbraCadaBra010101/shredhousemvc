using Microsoft.AspNetCore.Mvc;
using shredhousepage.Models;
using shredhousepage.Services;
using System;
using System.Threading.Tasks;

namespace shredhousepage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService mailService;
        public HomeController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] ContactFormModel request)
        {
         // map contactformmodel to mail rquest mapp and send as new object. 
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //[HttpPost]
        //public async Task<IActionResult> SendMail(MailRequest model)
        //{


        //    //if (ModelState.IsValid)
        //    //{
        //    //    //ContactFormModel msgToSend = new ContactFormModel
        //    //    //{
        //    //    //    FirstName = model.FirstName,
        //    //    //    LastName = model.LastName,
        //    //    //    Email = model.Email
        //    //    //};

        //    //    EmailService.SendEmailAsync(msgToSend);
        //    //    return RedirectToAction("Index");
        //    //}
        //    //else
        //    //{
        //    //    return Index();
        //    //}
        //}
    }
}
