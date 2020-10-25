using System.Collections.Generic;
using System.Linq;
using backend.Models;
using backend.Persistence;
using backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _IDepartment;
        public DepartmentController(IDepartment IDepartment)
        {
            _IDepartment = IDepartment;
        }

        //Get api/departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            var deptItems = _IDepartment.GetAllDepartments().Select(x => new DepartmentOutPutModel
            {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,
                CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd")
            });

            return Ok(deptItems); // 200 Ok
        }

        //Get api/departments/{id}
        [HttpGet("{id}", Name = "GetDepartmentById")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            var deptItem = _IDepartment.GetDepartmentById(id);

            var model = new DepartmentOutPutModel { 
            DepartmentID = deptItem.DepartmentID,
            DepartmentName = deptItem.DepartmentName,
            CreatedOn = deptItem.CreatedOn.ToString("dd/MM/yyyy")
            };

            if (model != null)
            {
                return Ok(model);
            }
            else
                return NotFound(); // 404 Not Found
         }

        //POST api/departments
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department deptCreate)
        {
            _IDepartment.CreateDepartment(deptCreate);

            var createdDept = new DepartmentOutPutModel
            {
                DepartmentID = deptCreate.DepartmentID,
                DepartmentName = deptCreate.DepartmentName,
                CreatedOn = deptCreate.CreatedOn.ToString("dd/MM/yyyy")
            };
            
            return CreatedAtRoute(nameof(GetDepartmentById), new { Id = createdDept.DepartmentID }, createdDept); // 201 Created
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(int id, Department deptUpdate)
        {
            var deptFromRepo = _IDepartment.GetDepartmentById(id);
            if (deptFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }


            
            _IDepartment.UpdateDepartment(deptUpdate,deptFromRepo);
            return NoContent(); // 204 No Content Success
        }

        //DELETE api/departments/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            var deptFromRepo = _IDepartment.GetDepartmentById(id);
            if (deptFromRepo == null)
            {
                return NotFound(); // 404 Not found
            }

            _IDepartment.DeleteDepartment(deptFromRepo);
            return NoContent(); // 204 No Content
        }
    }
}
