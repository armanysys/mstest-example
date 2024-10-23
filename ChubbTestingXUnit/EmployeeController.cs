using System.Data.Entity;

namespace ChubbTestingXUnit
{
    public class EmployeeController 
    {
        private readonly IEmployeeContext _db;

        // Constructor that accepts a context interface for dependency injection
        public EmployeeController(IEmployeeContext db)
        {
            // Assign the injected context to the private field
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // Method to save an employee
        public ActionResult SaveEmployee(Employee employee)
        {
            // If the employee ID is 0, add the employee to the database
            if (employee.Id == 0)
                _db.Employees.Add(employee);
            else
            {
                // Otherwise, update the existing employee
                var employeeInDb = _db.Employees.Find(employee.Id);
                if (employeeInDb == null)
                    return new NotFoundResult();

                employeeInDb.Name = employee.Name;
                // Add other properties as needed
            }

            // Save changes to the database
            _db.SaveChanges();
            // Redirect to the "Employees" action
            return RedirectToAction("Employees");
        }

        // Method to delete an employee by ID
        public ActionResult DeleteEmployee(int id)
        {
            // Find the employee by ID in the database
            var employee = _db.Employees.Find(id);
            // If the employee is not found, return a NotFoundResult
            if (employee == null)
                return new NotFoundResult();

            // Remove the employee from the database
            _db.Employees.Remove(employee);
            // Save changes to the database
            _db.SaveChanges();
            // Redirect to the "Employees" action
            return RedirectToAction("Employees");
        }


        // Method to redirect to a specified action
        private ActionResult RedirectToAction(string actionName)
        {
            // Return a new RedirectResult with the specified action name
            return new RedirectResult();
        }
    }

    // Interface for employee context to facilitate mocking
    public interface IEmployeeContext
    {
        // Property representing the Employees table
        DbSet<Employee> Employees { get; set; }
        // Method to save changes to the database
        void SaveChanges();
    }

    // ActionResult base class
    public class ActionResult { }

    // RedirectResult class inheriting from ActionResult
    public class RedirectResult : ActionResult { }
    
    // NotFoundResult class inheriting from ActionResult
    public class NotFoundResult : ActionResult { }

    // Employee entity class
    public class Employee
    {
        // Property for employee ID
        public int Id { get; set; }
        // Property for employee name
        public string Name { get; set; }
    }
}