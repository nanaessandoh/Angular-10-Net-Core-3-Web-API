using System.Collections.Generic;
using System.Linq;
using backend.Models;
using backend.Persistence;
using backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmpolyee;
        private readonly IDepartment _IDepartment;

        public EmployeeController(IEmployee IEmployee, IDepartment IDepartment)
        {
            _IEmpolyee = IEmployee;
            _IDepartment = IDepartment;
        }

        //Get api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeeItems = _IEmpolyee.GetAllEmployeees().Select(x => new EmployeeOutputModel { 
            EmployeeID = x.EmployeeID,
            EmployeeName = x.EmployeeName,
            Department = _IDepartment.GetDepartmentNameById(x.DepartmentId),
            Age = _IEmpolyee.AgeFromDOB(x.DOB),
            DOJ = x.DOJ.ToString("yyyy-MM-dd"),
            Gender = x.Gender
            });

            return Ok(employeeItems); // 200 Ok
        }

        //Get api/employees/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<Department> GetEmployeeById(int id)
        {
            var empItem = _IEmpolyee.GetEmployeeById(id);

            var model = new EmployeeOutputModel
            {
                EmployeeID = empItem.EmployeeID,
                EmployeeName = empItem.EmployeeName,
                Department = _IDepartment.GetDepartmentNameById(empItem.DepartmentId),
                Age = _IEmpolyee.AgeFromDOB(empItem.DOB),
                DOJ = empItem.DOJ.ToString("yyyy-MM-dd"),
                Gender = empItem.Gender

            };

            if (model != null)
            {
                return Ok(model);
            }
            else
                return NotFound(); // 404 Not Found
        }

        //POST api/employees
        [HttpPost]
        public ActionResult<Department> CreateEmployee(Employee empCreate)
        {
            _IEmpolyee.CreateEmployee(empCreate);
            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = empCreate.EmployeeID }, empCreate); // 201 Created
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee empUpdate)
        {
            var empFromRepo = _IEmpolyee.GetEmployeeById(id);
            if (empFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }

            _IEmpolyee.UpdateEmployee(empUpdate, empFromRepo);
            return NoContent(); // 204 No Content Success
        }

        //DELETE api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var empFromRepo = _IEmpolyee.GetEmployeeById(id);
            if (empFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }

            _IEmpolyee.DeleteEmployee(empFromRepo);
            return NoContent(); // 204 No Content
        }

    }
}
