using System;
using AutoSend_Email.Interface;
using AutoSend_Email.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoSend_Email.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult Email(Email request){
            _emailService.SendEmail(request);

            return Ok();
        }


    }
}
