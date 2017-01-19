using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Infrastructure.Common.Emailing
{
    public class FakeEmailService : IEmailService
    {
        public EmailSendingResult SendEmail(EmailArguments emailArguments)
        {
            string message = ($"From: {emailArguments.From}, to: {emailArguments.To}, message: {emailArguments.Message}, server: {emailArguments.SmtpServer}, subject: {emailArguments.Subject}");
            Debug.WriteLine(message);
            return new EmailSendingResult() { EmailSendingFailureMessage = "None", EmailSentSuccessfully = true };
        }
    }
}
