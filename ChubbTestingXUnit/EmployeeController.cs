using System.Data.Entity;

namespace ChubbTestingXUnit
{
    public class EmployeeController
    {
        private readonly IEmployeeContext _db;

        // Constructor that accepts a context interface for dependency injection
        public EmployeeController(IEmployeeContext db)
        {
            _db = db;
        }

        // Method to delete an employee by ID
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return new NotFoundResult();

            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        // Method to redirect to a specified action
        private ActionResult RedirectToAction(string actionName)
        {
            return new RedirectResult(actionName);
        }
    }

    // Interface for employee context to facilitate mocking
    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; set; }
        void SaveChanges();
    }

    // ActionResult base class
    public class ActionResult { }

    // RedirectResult class inheriting from ActionResult
    public class RedirectResult : ActionResult
    {
        public string ActionName { get; }

        public RedirectResult(string actionName)
        {
            ActionName = actionName;
        }
    }

    // NotFoundResult class inheriting from ActionResult
    public class NotFoundResult : ActionResult { }

    // EmployeeContext class implementing IEmployeeContext
    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }

    // Employee entity class
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}