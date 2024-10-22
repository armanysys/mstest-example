using Moq;
using System.Data.Entity;
using ChubbTestingXUnit; // Import the Moq library to create mock objects.

namespace XUnitTesting
{
    public class EmployeeShould
    {
        [Fact] // Indicates that this method is a unit test to be run by XUnit.
        public void DeleteEmployee_WhenCalled_ShouldRemoveEmployeeFromDb() // Name of the test method describing what it tests.
        {
            // Arrange: Set up the test scenario.
            var mockDbSet = new Mock<DbSet<Employee>>(); // Create a mock for DbSet<Employee>.
            var mockContext = new Mock<EmployeeContext>(); // Create a mock for EmployeeContext.
            mockContext.Setup(c => c.Employees).Returns(mockDbSet.Object); // Configure the mockContext to return the mockDbSet when accessing the Employees property.

            var controller =  new EmployeeController(mockContext.Object); // Create an instance of EmployeeController using the mockContext.

            // Act: Execute the method being tested.
            controller.DeleteEmployee(1); // Call the DeleteEmployee method with an ID of 1.

            // Assert: Verify that the method behaved as expected.
            mockDbSet.Verify(m => m.Find(1), Times.Once); // Verify that the Find method was called once with ID 1.
            mockDbSet.Verify(m => m.Remove(It.IsAny<Employee>()), Times.Once); // Verify that the Remove method was called once with any Employee instance.
            mockContext.Verify(c => c.SaveChanges(), Times.Once); // Verify that the SaveChanges method was called once.
        }
    }
}
