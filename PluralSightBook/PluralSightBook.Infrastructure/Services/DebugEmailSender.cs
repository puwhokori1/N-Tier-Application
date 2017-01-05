using System;
using System.Diagnostics;
using System.Linq;
using PluralSightBook.Core.Interfaces;

namespace PluralSightBook.Infrastructure.Services
{
    public class DebugEmailSender : ISendEmail
    {
        public void SendEmail(string message)
        {
            // send email
            Debug.Print(string.Format("Sending Email: {0}", message));
        }
    }
}