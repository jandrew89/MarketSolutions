﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Infrastructure.Common.Emailing
{
    public interface IEmailService
    {
        EmailSendingResult SendEmail(EmailArguments emailArguments);
    }
}
