using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChubbTestingXUnit
{
    public class MailValidator
    {
        public bool IsValidaEmail(String emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new EmailNotProvidedException();

            Regex regex = new Regex(@"^[\w0-9.%+-]+@[\w0-9.-]+\.[\w]{2,6}$");
            return regex.IsMatch(emailAddress);
        }

        public string IsSpam(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new EmailNotProvidedException();

            List<string> spammDomains = new List<string>() { "spam.com", "dodgy.com", "donttrust.com" };
            return spammDomains.Any(d => emailAddress.Contains(d)) ? "SPAM" : "INBOX";
        }
    }
}
