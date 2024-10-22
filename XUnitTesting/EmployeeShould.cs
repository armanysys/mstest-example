using Moq;
using System.Data.Entity;
using ChubbTestingXUnit; // Import the Moq library to create mock objects.

namespace XUnitTesting
{
    public class EmployeeShould
    {
        private readonly Mock<IEmployeeContext> _mockContext;
        private readonly EmployeeController _controller;

        // Constructor to set up the mock context and controller
        public EmployeeShould()
        {
            // Create a mock of the IEmployeeContext
            _mockContext = new Mock<IEmployeeContext>();
            // Initialize the controller with the mock context
            _controller = new EmployeeController(_mockContext.Object);
        }

        [Fact]
        public void DeleteEmployee_EmployeeExists_ReturnsRedirectResult()
        {
            // Arrange
            // Create a sample employee
            var employee = new Employee { Id = 1, Name = "John Doe" };
            // Create a mock DbSet for employees
            var mockSet = new Mock<DbSet<Employee>>();
            // Set up the mock to return the sample employee when Find is called
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(employee);
            // Set up the mock context to return the mock DbSet
            _mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            // Act
            // Call the DeleteEmployee method
            var result = _controller.DeleteEmployee(1);

            // Assert
            // Verify that the result is a RedirectResult
            Assert.IsType<RedirectResult>(result);
            // Verify that Remove was called once with the sample employee
            _mockContext.Verify(c => c.Employees.Remove(employee), Times.Once);
            // Verify that SaveChanges was called once
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteEmployee_EmployeeDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            // Create a mock DbSet for employees
            var mockSet = new Mock<DbSet<Employee>>();
            // Set up the mock to return null when Find is called
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns((Employee)null);
            // Set up the mock context to return the mock DbSet
            _mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            // Act
            // Call the DeleteEmployee method
            var result = _controller.DeleteEmployee(1);

            // Assert
            // Verify that the result is a NotFoundResult
            Assert.IsType<NotFoundResult>(result);
            // Verify that Remove was never called
            _mockContext.Verify(c => c.Employees.Remove(It.IsAny<Employee>()), Times.Never);
            // Verify that SaveChanges was never called
            _mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }
    }
}
