﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IEmailService
    {
        public void SendEmail(string email, string subject, string body);
    }
}
