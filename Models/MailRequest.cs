using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shredhousepage.Models
{
    public class MailRequest
    {
        //public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Body { get; set; }

        // in case we want to upload files.
        public List<IFormFile> Attachments { get; set; }
    }
}
