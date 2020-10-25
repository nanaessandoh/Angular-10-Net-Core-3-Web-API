using backend.Persistence;
using System.Collections.Generic;

namespace backend.Repository.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployeees();
        Employee GetEmployeeById(int empId);
        void CreateEmployee(Employee emp);
        void UpdateEmployee(Employee empUpdate, Employee empFromRepo);
        void DeleteEmployee(Employee emp);
    }
}
