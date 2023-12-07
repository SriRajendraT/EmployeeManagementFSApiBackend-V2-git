using EmployeeManagementFSApiBackend.Models;

namespace EmployeeManagementFSApiBackend.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeExt> GetAllEmployees();
        Task<EmployeeExt> GetEmployeeById(int id);

        List<EState> GetAllStates();
        List<City> GetAllCitiesByStateId(int state_id);
        List<Department> GetAllDepartments();
        List<Gender> GetAllGenders();
        Task<bool> DeleteEmployee(int id);
        Task<Employee> SaveEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
    }
}
