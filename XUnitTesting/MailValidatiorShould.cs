﻿

using ChubbTestingXUnit;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml.Linq;

namespace XUnitTesting
{
    public class MailValidatiorShould
    { 
    // Naming convention in every test method has three parts:
    // 1. Name of the method being tested
    // 2. Scenario being tested
    // 3. Expected behavior 
        [Fact]
        public void IsValidEmail_ValidEmail_ReturnTrue()
        {
            // AAA pattern is a common approach in unit testing that helps structure tests.
            // Arrange: Set up the necessary conditions and inputs for the test.
            var mailvalidator = new MailValidator();
            string emailaddress = "armando.antonio@gmail.com";

            // Act: Execute the operation or method being tested.
            bool isvalid = mailvalidator.IsValidEmail(emailaddress);

            // Assert: Verify that the outcome matches the expected result.
            Assert.True(isvalid, $"{emailaddress} is not valid.");
        }

        [Fact]
        public void IsValidEmail_InValidEmail_ReturnFalse()
        {
            // AAA pattern is a common approach in unit testing that helps structure tests.
            // Arrange: Set up the necessary conditions and inputs for the test.
            var mailvalidator = new MailValidator();
            string emailaddress = "invalid.invalid@invalid.com";

            // Act: Execute the operation or method being tested.
            bool isvalid = mailvalidator.IsValidEmail(emailaddress);

            // Assert: Verify that the outcome matches the expected result.
            Assert.False(isvalid, $"{emailaddress} is not valid.");
        }

       // // Permite hacer data driven testing
       //[Theory]
       //[InlineData("invalid@invalid.invalid", false)]
       //[InlineData("armando.antonio@chubb.com", true)]
       // public void ValidateValidEmails(string emailAddress, bool expected)
       // {
       //     // Pattern AAA
       //     // Arrange - Define all variables we use
       //     var mailValidator = new MailValidator();

       //     // Act  - All I declared in arragne, we use in Act
       //     bool isValid = mailValidator.IsValidaEmail(emailAddress);

       //     // Assert - Has static method... Verifica que IsValid is true
       //     Assert.Equal(expected, isValid);
       // }

        [Theory]
        [InlineData("spam@gmail.com", "INBOX")]
        [InlineData("spam@spam.com", "SPAM")]
        public void IndentifySpam(string emailAddress, string expected)
        {
            // Arrange
            var mailValidator = new MailValidator();

            // Act
            string result = mailValidator.IsSpam(emailAddress);

            // Act
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RaiseErrorWhenEmailIsEmpty() 
        {
            // Arrange
            var mailValidator = new MailValidator();

            // Act

            // Act
            Assert.Throws<EmailNotProvidedException>(() => mailValidator.IsValidaEmail(null));
        }
    }
}
