using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementFSApiBackend.Models
{
    public class Department
    {
        [Key]
        public int dept_id { get; set; }
        public string dept_name { get; set; }
    }
}
