using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementFSApiBackend.Models
{
    public class Gender
    {
        [Key]
        public int gender_id { get; set; }
        public string gender_name { get; set; }
    }
}
