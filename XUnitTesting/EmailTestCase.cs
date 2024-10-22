using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTesting
{
    public class EmailTestCase
    {
        public string EmailAddress { get; }
        public bool Expected { get; }

        public EmailTestCase(string emailAddress, bool expected)
        {
            EmailAddress = emailAddress;
            Expected = expected;
        }
    }
}
