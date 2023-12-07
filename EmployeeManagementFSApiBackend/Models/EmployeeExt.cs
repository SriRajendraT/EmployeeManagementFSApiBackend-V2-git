using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementFSApiBackend.Models
{
    [NotMapped]
    public class EmployeeExt:Employee
    {
        public string state_name { get; set; }
        public string city_name { get; set; }
        public string dept_name { get; set; }
        public string gender_name { get; set; }
    }
}
