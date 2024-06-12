﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mail
{
    public class MailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Host { get; set; }
        public string UserName { get; set; }
        public int Port { get; set; }
    }
}
