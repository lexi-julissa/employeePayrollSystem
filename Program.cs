using System;

// Employee Payroll System
// Demonstrates object-oriented programming concepts including inheritance,
// encapsulation, constructor overloading, and method overriding.

namespace EmployeePayroll
{
    // Create an Employee class with the following:
    public class Employee
    {
        protected string name; //Protected String name
        protected int weeklyWage; //Protected int weeklyWage
        protected string password; //Protected string password

        // Default constructor
        public Employee()
        {
            name = "unknown";
            weeklyWage = -1;
            password = "abc123";
        }

        // Parameter constructor
        public Employee(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.weeklyWage = -1; // Default value until updated
        }

        // Protected virtual details method
        protected virtual void details()
        {
            Console.WriteLine("Employee Name: {0}", name);
        }//instance method details

        // Public method to change the password
        public void changePassword()
        {
            Console.Write("Enter current password: ");
            string currentPassword = Console.ReadLine();

            if (currentPassword == password)
            {
                Console.Write("Enter new password: ");
                password = Console.ReadLine();
                Console.WriteLine("Password updated successfully :)");
            }
            else
            {
                Console.WriteLine("Incorrect, password not changed :(");
            }
        }//instance method changePassword
    }//employee class

    // Derived FullTime class
    public class FullTime : Employee //Inherits the Employee class
    {
        protected int yearlySalary;

        // Constructor with 3 parameters
        public FullTime(int yearlySalary, string name, string password)
            : base(name, password)
        {
            this.yearlySalary = yearlySalary;
            UpdateWage();
        }

        // Method to update weekly wage
        private void UpdateWage() //An updateWage() method which sets the weeklyWage to yearlySalaray / 48
        {
            weeklyWage = yearlySalary / 48;
        }

        // Protected override of details method
        protected override void details()
        {
            base.details();
            Console.Write("Enter password to view salary details: ");
            string inputPassword = Console.ReadLine();

            if (inputPassword == password)
            {
                Console.WriteLine("Yearly Salary: ${0}",yearlySalary);
                Console.WriteLine("Weekly Wage: ${0}", weeklyWage);
            }
            else
            {
                Console.WriteLine("Incorrect password, access denied :(");
            }
        }

        // Main method for testing
        public static void Main(string[] args)
        {
            // Create two FullTime employees
            FullTime employee1 = new FullTime(10000, "Anakin", "password123");
            FullTime employee2 = new FullTime(20000, "Padme", "pass321");

            // Change the password for the first employee
            Console.WriteLine("\n--- Change Password for Employee 1 ---");
            employee1.changePassword();

            // Display details for both employees
            Console.WriteLine("\n--- Employee 1 Details ---");
            employee1.details();

            Console.WriteLine("\n--- Employee 2 Details ---");
            employee2.details();
        }//main
    }//fulltime class
}//namespace
