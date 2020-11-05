using backend.Persistence;
using backend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace backend.Repository
{
    public class DepartmentService : IDepartment
    {
        public void CreateDepartment(Department dept)
        {
            using var _context = new AppDBContext();
            if (dept == null)
            {
                throw new ArgumentNullException(nameof(dept));
            }

            _context.Departments.Add(dept);
            _context.SaveChanges();
        }

        public void DeleteDepartment(Department dept)
        {
            using var _context = new AppDBContext();
            if (dept == null)
            {
                throw new ArgumentNullException(nameof(dept));
            }
            _context.Departments.Remove(dept);
            _context.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            using var _context = new AppDBContext();
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int deptId)
        {
            using var _context = new AppDBContext();
            return _context.Departments.FirstOrDefault(x => x.DepartmentID == deptId);
        }


        public string GetDepartmentNameById(int deptId)
        {
            using var _context = new AppDBContext();
            var deptName =  _context.Departments.FirstOrDefault(x => x.DepartmentID == deptId).DepartmentName;
            return deptName == null ?  "Not-Affiliated": deptName;
        }

        public void UpdateDepartment(Department deptUpdate, Department deptFromRepo)
        {
            using var _context = new AppDBContext();
            _context.Update(deptFromRepo);
            deptFromRepo.DepartmentName = deptUpdate.DepartmentName;
            deptFromRepo.CreatedOn = deptUpdate.CreatedOn;
            _context.SaveChanges();     
        }
    }
}
