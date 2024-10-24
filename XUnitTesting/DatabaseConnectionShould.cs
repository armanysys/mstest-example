using ChubbTestingXUnit;
using Microsoft.Extensions.Options;
using Moq;

namespace XUnitTesting
{
    public class DatabaseConnectionShould
    {
        private readonly DatabaseConfiguration _configData = new DatabaseConfiguration
        {
            ConnectionString = "TestConnectionString"
        };
        // This attribute marks the method as a test method in xUnit.
        [Fact]
        public void WhenMockingIOptionsWithMoq_ThenCorrectConnectionStringIsReturned()
        {
            // Create a mock object for IOptions<DatabaseConfiguration> using Moq.
            var configMock = new Mock<IOptions<DatabaseConfiguration>>();
            // Set up the mock to return _configData when the Value property is accessed.
            configMock.Setup(x => x.Value).Returns(_configData);

            // Create an instance of CustomerService, passing the mock object.
            var sut = new CustomerService(configMock.Object);
            // Call the GetConnectionString method on the CustomerService instance.
            var result = sut.GetConnectionString();

            // Assert that the result is equal to "TestConnectionString".
            Assert.Equal("TestConnectionString", result);
        }

        // This attribute marks the method as a test method in xUnit.
        [Fact]
        public void WhenMockingIOptionsWithOptionsWrapper_ThenCorrectConnectionStringIsReturned()
        {
            // Create an OptionsWrapper object for DatabaseConfiguration with _configData.
            var configWrapper = new OptionsWrapper<DatabaseConfiguration>(_configData);

            // Create an instance of CustomerService, passing the OptionsWrapper object.
            var sut = new CustomerService(configWrapper);
            // Call the GetConnectionString method on the CustomerService instance.
            var result = sut.GetConnectionString();

            // Assert that the result is equal to "TestConnectionString".
            Assert.Equal("TestConnectionString", result);
        }

        // This attribute marks the method as a test method in xUnit.
        [Fact]
        public void WhenMockingIOptionsWithOptionsHelper_ThenCorrectConnectionStringIsReturned()
        {
            // Create an IOptions object for DatabaseConfiguration using Options.Create helper method.
            var configWrapperUsingHelper = Options.Create(_configData);

            // Create an instance of CustomerService, passing the IOptions object.
            var sut = new CustomerService(configWrapperUsingHelper);
            // Call the GetConnectionString method on the CustomerService instance.
            var result = sut.GetConnectionString();

            // Assert that the result is equal to "TestConnectionString".
            Assert.Equal("TestConnectionString", result);
        }

    }
}

