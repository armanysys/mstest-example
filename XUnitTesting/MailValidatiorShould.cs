

using ChubbTestingXUnit;

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
            string emailaddress = "invalid.invalid@invalid";

            // Act: Execute the operation or method being tested.
            bool isvalid = mailvalidator.IsValidEmail(emailaddress);

            // Assert: Verify that the outcome matches the expected result.
            Assert.False(isvalid, $"{emailaddress} is not valid.");
        }

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

        //// Define a static method that returns a collection of test data for emails.
        //public static IEnumerable<object[]> EmailTestData()
        //{
        //    // Returns an object with an invalid email and the expected result (false).
        //    yield return new object[] { "invalid@invalid.invalid", false };
        //    // Returns an object with a valid email and the expected result (true).
        //    yield return new object[] { "armando.antonio@chubb.com", true };
        //}

        //// Indicates that this method is a test theory and uses test data provided by EmailTestData.
        //[Theory]
        //[MemberData(nameof(EmailTestData))]
        //public void IsValidValidEmails_MemberData(string emailAddress, bool expected)
        //{
        //    // Arrange: Create an instance of the email validator.
        //    var mailValidator = new MailValidator();

        //    // Act: Validate the provided email address.
        //    bool isValid = mailValidator.IsValidEmail(emailAddress);

        //    // Assert: Verify that the validation result matches the expected result.
        //    Assert.Equal(expected, isValid);
        //}

        //// Define another static method that returns a collection of test data, but using a test case class.
        //public static IEnumerable<object[]> EmailTestDataObject()
        //{
        //    // Returns an object with a test case of an invalid email.
        //    yield return new object[] { new EmailTestCase("invalid@invalid.invalid", false) };
        //    // Returns an object with a test case of a valid email.
        //    yield return new object[] { new EmailTestCase("armando.antonio@chubb.com", true) };
        //}

        //// Indicates that this method is a test theory and uses test data provided by EmailTestDataObject.
        //[Theory]
        //[MemberData(nameof(EmailTestDataObject))]
        //public void IsValidValidEmails_MemberDataClass(EmailTestCase emailTestCase)
        //{
        //    // Arrange: Create an instance of the email validator.
        //    var mailValidator = new MailValidator();

        //    // Act: Validate the email address provided in the test case.
        //    bool isValid = mailValidator.IsValidEmail(emailTestCase.EmailAddress);

        //    // Assert: Verify that the validation result matches the expected result.
        //    Assert.Equal(emailTestCase.Expected, isValid);
        //}

        //// Indicates that this method is a test theory and uses test data provided by a test data class.
        //[Theory]
        //[ClassData(typeof(TestDataClass))]
        //public void IsValidValidEmails_TestDataClass(EmailTestCase emailTestCase)
        //{
        //    // Arrange: Create an instance of the email validator.
        //    var mailValidator = new MailValidator();

        //    // Act: Validate the email address provided in the test case.
        //    bool isValid = mailValidator.IsValidEmail(emailTestCase.EmailAddress);

        //    // Assert: Verify that the validation result matches the expected result.
        //    Assert.Equal(emailTestCase.Expected, isValid);
        //}


        // Indicates that this method is a test theory and uses inline data for testing.
        [Theory]
        [InlineData("spam@gmail.com", "INBOX")]
        [InlineData("spam@spam.com", "SPAM")]
        public void IndentifySpam(string emailAddress, string expected)
        {
            // Arrange: Create an instance of the email validator.
            var mailValidator = new MailValidator();

            // Act: Identify if the provided email address is spam.
            string result = mailValidator.IsSpam(emailAddress);

            // Assert: Verify that the result matches the expected value.
            Assert.Equal(expected, result);
        }

        // Indicates that this method is a fact test.
        [Fact]
        public void RaiseErrorWhenEmailIsEmpty()
        {
            // Arrange: Create an instance of the email validator.
            var mailValidator = new MailValidator();

            // Act: (No action needed as we are testing for an exception)

            // Assert: Verify that an exception is thrown when the email is null.
            Assert.Throws<EmailNotProvidedException>(() => mailValidator.IsValidEmail(null));
        }

    }
}
