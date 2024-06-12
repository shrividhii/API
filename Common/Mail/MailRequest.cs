using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mail
{
    public class MailRequest
    {
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
