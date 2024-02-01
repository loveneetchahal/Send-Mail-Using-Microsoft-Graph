using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Send_Mail_Using_Microsoft_Graph.Application.Microsoft.Graph.Mail;
using Send_Mail_Using_Microsoft_Graph.Models;

namespace Send_Mail_Using_Microsoft_Graph.Controllers
{
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IMsGraphMailAppService _msGraphMailAppService;

        public MailController(IMsGraphMailAppService msGraphMailAppService)
        {
            _msGraphMailAppService = msGraphMailAppService;
        }

        [HttpGet]
        public async Task<IActionResult> SendMailTest(GraphMail mail)
        {
            //GraphMail mail = new GraphMail()
            //{
            //    FromEmail = "chsc@christian-schou.dk",
            //    ToEmail = "someone@awesomeness.com",
            //    Subject = "Hello this is a test",
            //    Content = "Here goes the content inside the email.",
            //    ContentType = BodyType.Html,
            //    SaveToSentItems = true
            //};

            await _msGraphMailAppService.SendAsync(mail);

            return Ok("Message sent!");
        }
    }
}

