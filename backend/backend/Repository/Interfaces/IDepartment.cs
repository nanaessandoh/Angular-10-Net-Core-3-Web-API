using backend.Persistence;
using System.Collections.Generic;

namespace backend.Repository.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int deptId);
        void CreateDepartment(Department dept);
        void UpdateDepartment(Department deptUpdate, Department deptFromRepo);
        void DeleteDepartment(Department dept);
        string GetDepartmentNameById(int deptId);
    }
}
