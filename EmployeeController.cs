using MultipartDataMediaFormatter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Reflection;
using WebApiProject.Models;
using System.IO;
using Newtonsoft.Json;
namespace WebApiTest.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employees = new List<Employee>();
        public EmployeeController()
        {
            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            employees.Add(new Employee("mor", "asd@gmail.com", "123123", Employee.EmployeeRole.Manager, DateTime.UtcNow));
            employees.Add(new Employee("daniel", "daniel@gmail.com", "321", Employee.EmployeeRole.Employee, DateTime.UtcNow));
            employees.Add(new Employee("shabi", "shabi@gmail.com", "123", Employee.EmployeeRole.Employee, DateTime.UtcNow.AddYears(-1)));
        }

        public IEnumerable<Employee> GetEmployessBySeniority()
        {
            DateTime lastYear = DateTime.UtcNow.AddYears(-1);
            return GetAllEmployees().Where(x => x.StartDate != null && (x.StartDate <= lastYear)).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
           return employees;
            
        }

        public IHttpActionResult GetEmployee(string id)
        {
            var Employee = GetAllEmployees().FirstOrDefault((e) => e.UniqueId == id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }


 


        [HttpPost]
        public object Post([FromBody]Employee data)
        {
            return null;
        }

        [HttpDelete]
        public void Delete(string id)
        {
            var Employee = GetAllEmployees().FirstOrDefault((e) => e.UniqueId == id);
            GetAllEmployees().ToList().Remove(Employee);
        }

        public List<Employee> LoadJson()
        {
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "employees.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Employee> items = JsonConvert.DeserializeObject<List<Employee>>(json);
                return items;
            }
        }

    }
}
