using EmployeeManagementFSApiBackend.Models;
using EmployeeManagementFSApiBackend.Repository;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeManagementFSApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFSApiController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeFSApiController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeeFSApiController>
        [HttpPost("GetAllEmployees")]
        public List<EmployeeExt> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return employees;
        }

        // GET api/<EmployeeFSApiController>/5
        [HttpPost("GetEmployeeById")]
        public async Task<EmployeeExt> GetEmployeeById([FromBody] KeyValue kv)
        {

            var employee = await _employeeRepository.GetEmployeeById(kv.value1);
            return employee;
        }

        [HttpPost("GetAllStates")]
        public List<EState> GetAllStates()
        {
            var states = _employeeRepository.GetAllStates();
            return states;
        }

        [HttpPost("GetAllCitiesByStateId")]
        public List<City> GetAllCitiesByStateId([FromBody] KeyValue kv)
        {
            var cities = _employeeRepository.GetAllCitiesByStateId(kv.value1);
            return cities;
        }

        [HttpPost("GetAllDepartments")]
        public List<Department> GetAllDepartments()
        {
            var departments = _employeeRepository.GetAllDepartments();
            return departments;
        }

        [HttpPost("GetAllGenders")]
        public List<Gender> GetAllGenders()
        {
            var genders = _employeeRepository.GetAllGenders();
            return genders;
        }

        // POST api/<EmployeeFSApiController>
        [HttpPost("SaveEmployee")]
        public async Task<Employee> SaveEmployee([FromBody] Employee employee)
        {
            var employee1 = await _employeeRepository.SaveEmployee(employee);
            return employee1;
        }

        // PUT api/<EmployeeFSApiController>/5
        [HttpPost("UpdateEmployee")]
        public async Task<int> UpdateEmployee([FromBody] Employee employee)
        {
            var emp = await _employeeRepository.UpdateEmployee(employee);
            return emp;
        }

        // DELETE api/<EmployeeFSApiController>/5
        [HttpPost("DeleteEmployee")]
        public async Task<bool> DeleteEmployee([FromBody] KeyValue kv)
        {
            var empExist = await _employeeRepository.DeleteEmployee(kv.value1);
            return empExist;
        }
    }
}
