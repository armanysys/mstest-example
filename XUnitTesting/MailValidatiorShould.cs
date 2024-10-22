

using ChubbTestingXUnit;

namespace XUnitTesting
{
    public class MailValidatiorShould
    {
        // Naming convention in every test method has three parts:
        // 1. Name of the method being tested
        // 2. Scenario being tested
        // 3. Expected behavior 
        //[Fact]
        //public void IsValidEmail_ValidEmail_ReturnTrue()
        //{
        //    // AAA pattern is a common approach in unit testing that helps structure tests.
        //    // Arrange: Set up the necessary conditions and inputs for the test.
        //    var mailvalidator = new MailValidator();
        //    string emailaddress = "armando.antonio@gmail.com";

        //    // Act: Execute the operation or method being tested.
        //    bool isvalid = mailvalidator.IsValidEmail(emailaddress);

        //    // Assert: Verify that the outcome matches the expected result.
        //    Assert.True(isvalid, $"{emailaddress} is not valid.");
        //}

        //[Fact]
        //public void IsValidEmail_InValidEmail_ReturnFalse()
        //{
        //    // AAA pattern is a common approach in unit testing that helps structure tests.
        //    // Arrange: Set up the necessary conditions and inputs for the test.
        //    var mailvalidator = new MailValidator();
        //    string emailaddress = "invalid.invalid@invalid";

        //    // Act: Execute the operation or method being tested.
        //    bool isvalid = mailvalidator.IsValidEmail(emailaddress);

        //    // Assert: Verify that the outcome matches the expected result.
        //    Assert.False(isvalid, $"{emailaddress} is not valid.");
        //}

        //// Permite hacer data driven testing
        //[Theory]
        //[InlineData("invalid@invalid.invalid", false)]
        //[InlineData("armando.antonio@chubb.com", true)]
        //public void IsValidValidEmails_InlineData(string emailAddress, bool expected)
        //{
        //    // Pattern AAA
        //    // Arrange - Define all variables we use
        //    var mailValidator = new MailValidator();

        //    // Act  - All I declared in arragne, we use in Act
        //    bool isValid = mailValidator.IsValidEmail(emailAddress);

        //    // Assert - Has static method... Verifica que IsValid is true
        //    Assert.Equal(expected, isValid);
        //}

        public static IEnumerable<object[]> EmailTestData()
        {
            yield return new object[] { "invalid@invalid.invalid", false };
            yield return new object[] { "armando.antonio@chubb.com", true };
        }

        [Theory]
        [MemberData(nameof(EmailTestData))]
        public void IsValidValidEmails_MemberData(string emailAddress, bool expected)
        {
            // Arrange
            var mailValidator = new MailValidator();

            // Act
            bool isValid = mailValidator.IsValidEmail(emailAddress);

            // Assert
            Assert.Equal(expected, isValid);
        }

        public static IEnumerable<object[]> EmailTestDataObject()
        {
            yield return new object[] { new EmailTestCase("invalid@invalid.invalid", false) };
            yield return new object[] { new EmailTestCase("armando.antonio@chubb.com", true) };
        }

        [Theory]
        [MemberData(nameof(EmailTestDataObject))]
        public void IsValidValidEmails_MemberDataClass(EmailTestCase emailTestCase)
        {
            // Arrange
            var mailValidator = new MailValidator();

            // Act
            bool isValid = mailValidator.IsValidEmail(emailTestCase.EmailAddress);

            // Assert
            Assert.Equal(emailTestCase.Expected, isValid);
        }

        [Theory]
        [ClassData(typeof(TestDataClass))]
        public void IsValidValidEmails_TestDataClass(EmailTestCase emailTestCase)
        {
            // Arrange
            var mailValidator = new MailValidator();

            // Act
            bool isValid = mailValidator.IsValidEmail(emailTestCase.EmailAddress);

            // Assert
            Assert.Equal(emailTestCase.Expected, isValid);
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

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RaiseErrorWhenEmailIsEmpty() 
        {
            // Arrange
            var mailValidator = new MailValidator();

            // Act

            // Assert
            Assert.Throws<EmailNotProvidedException>(() => mailValidator.IsValidEmail(null));
        }
    }
}
