

using ChubbTestingXUnit;
using System.Net.Mail;

namespace XUnitTesting
{
    public class MailValidatiorShould
    {
        //[Fact]
        //public void ValidateValidEmails()
        //{
        //    // Pattern AAA
        //    // Arrange - Define all variables we use
        //    var mailValidator = new MailValidator();
        //    string emailAddress = "armando.antonio@gmail.com";

        //    // Act  - All I declared in arragne, we use in Act
        //    bool isValid = mailValidator.IsValidaEmail(emailAddress);

        //    // Assert - Has static method... Verifica que IsValid is true
        //    Assert.True(isValid,$"{emailAddress} is not valid.");
        //}

        //[Fact]
        //public void InvalidateInvalidEmails()
        //{
        //    // Pattern AAA
        //    // Arrange - Define all variables we use
        //    var mailValidator = new MailValidator();
        //    string emailAddress = "invalid.invalid@invalid.com";

        //    // Act  - All I declared in arragne, we use in Act
        //    bool isValid = mailValidator.IsValidaEmail(emailAddress);

        //    // Assert - Has static method... Verifica que IsValid is true
        //    Assert.False(isValid, $"{emailAddress} is not valid.");
        //}

        // Permite hacer data driven testing
        [Theory]
        [InlineData("invalid@invalid.invalid", false)]
        [InlineData("armando.antonio@chubb.com", true)]
        public void ValidateValidEmails(string emailAddress, bool expected)
        {
            // Pattern AAA
            // Arrange - Define all variables we use
            var mailValidator = new MailValidator();

            // Act  - All I declared in arragne, we use in Act
            bool isValid = mailValidator.IsValidaEmail(emailAddress);

            // Assert - Has static method... Verifica que IsValid is true
            Assert.Equal(expected, isValid);
        }

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
