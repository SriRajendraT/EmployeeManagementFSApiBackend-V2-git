using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementFSApiBackend.Models
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_phone { get; set; }
        public string emp_email { get; set; }
        public decimal emp_salary { get; set; }
        public int emp_gender { get; set; }
        public int emp_dept { get; set; }
        public int emp_city { get; set; }
        public int emp_state { get; set; }
        public string emp_activeflag { get; set; } = "Y";
    }
}
