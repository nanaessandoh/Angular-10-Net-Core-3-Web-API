using backend.Persistence;
using backend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Repository
{
    public class EmployeeService : IEmployee
    {
        public void CreateEmployee(Employee emp)
        {
            using var _context = new AppDBContext();
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee emp)
        {
            using var _context = new AppDBContext();
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployeees()
        {
            using var _context = new AppDBContext();
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int empId)
        {
            using var _context = new AppDBContext();
            return _context.Employees.FirstOrDefault(x => x.EmployeeID == empId);
        }

        public void UpdateEmployee(Employee empUpdate, Employee empFromRepo)
        {
            // Do Nothing
            using var _context = new AppDBContext();
            _context.Update(empFromRepo);
            empFromRepo.EmployeeName = empUpdate.EmployeeName;
            empFromRepo.DOB = empUpdate.DOB;
            empFromRepo.DOJ = empUpdate.DOJ;
            empFromRepo.Gender = empUpdate.Gender;
            empFromRepo.DepartmentId = empUpdate.DepartmentId;
            _context.SaveChanges();
        }
    }
}
