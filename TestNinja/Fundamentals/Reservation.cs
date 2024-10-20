using System.Runtime.Remoting.Messaging;

namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }
        // Three scenarios
        // When the User is Admin
        // When the User Made the reservation
        // When somenelse try to cancel the reservation
        public bool CanBeCancelledBy(User user)
        {
            if (user.IsAdmin)
                return true;

            if (MadeBy == user)
                return true;

            return false;

            //return (user.IsAdmin || MadeBy == user);
        }


        // Confidence for refactorin.
        // public bool CanBeCancelledBy(User user) => (user.IsAdmin || MadeBy == user);
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}