using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class EmployeeOutputModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
    }
}
