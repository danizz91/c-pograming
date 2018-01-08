using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class Employee
    {
        public enum EmployeeRole
        {
            Employee,
            Manager
        };
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public EmployeeRole Role { get; set; }
        public DateTime StartDate { get; set; }

        public string UniqueId
        {
            get { return (this.FullName + "_" + this.Email).ToLower(); ; }
        }

        public Employee()
        {

        }

        public Employee(string fullName, string email, string phoneNumber, EmployeeRole role, DateTime startDate)
        {
            if (String.IsNullOrEmpty(fullName) || String.IsNullOrEmpty(email))
            {
                throw new Exception("Missing FullName Or Email For Employee");
            }

            this.FullName = fullName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
            this.StartDate = startDate;
        }
    }
}