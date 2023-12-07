using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementFSApiBackend.Models
{
    public class EState
    {
        [Key]
        public int state_id { get; set; }
        public string state_name { get; set; }
    }
}
