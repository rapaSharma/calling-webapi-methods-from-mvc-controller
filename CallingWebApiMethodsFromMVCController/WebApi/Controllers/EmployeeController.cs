using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private static readonly List<Employee> Employees = new List<Employee>
        {
            new Employee
            {
                City = "Tumakuru",
                Id = 1,
                Name = "Sharma"
            },
            new Employee
            {
                City = "Bengaluru",
                Id = 2,
                Name = "Vijay"
            },
            new Employee
            {
                City = "Hyderabad",
                Id = 3,
                Name = "Uma Maheshwar"
            }
        };

        [HttpGet]
        [Route("GetEmployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return Employees;
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] Employee employee)
        {
            Employees.Add(employee);
        }
    }
}