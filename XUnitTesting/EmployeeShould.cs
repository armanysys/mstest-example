using Moq;
using System.Data.Entity;
using ChubbTestingXUnit; // Import the Moq library to create mock objects.

namespace XUnitTesting
{
    public class EmployeeShould
    {
        private readonly Mock<IEmployeeContext> _mockContext;
        private readonly EmployeeController _controller;

        public EmployeeShould()
        {
            _mockContext = new Mock<IEmployeeContext>();
            _controller = new EmployeeController(_mockContext.Object);
        }

        [Fact]
        public void DeleteEmployee_EmployeeExists_ReturnsRedirectResult()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "John Doe" };
            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(employee);
            _mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            // Act
            var result = _controller.DeleteEmployee(1);

            // Assert
            Assert.IsType<RedirectResult>(result);
            _mockContext.Verify(c => c.Employees.Remove(employee), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteEmployee_EmployeeDoesNotExist_ReturnsNotFoundResult()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns((Employee)null);
            _mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            // Act
            var result = _controller.DeleteEmployee(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockContext.Verify(c => c.Employees.Remove(It.IsAny<Employee>()), Times.Never);
            _mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }
    }
}
