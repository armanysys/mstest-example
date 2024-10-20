using TestNinja.Fundamentals;

namespace MstestExample.UnitTest
{
    [TestClass]
    public class ReservationTests
    {
        //
        [TestMethod]

        //Name convention in every test method has 3tr parts
        //1 Name of the method Tested
        //2 Escenario where Testing
        //3 Expected behavior 
        public void CanBeCancellBy_UserIsAdmin_ReturnTrue()
        {
            // Insie in every test methos has 3rd parts or TRIPLE AAA
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancellBy_MadeByUser_ReturnTrue()
        {

            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancellBy_OtherUserCancellingReservation_ReturnFalse()
        {

            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            var result = reservation.CanBeCancelledBy(new User());

            // Assert
            Assert.IsFalse(result);
        }
    }
}