using EmployeeManagementFSApiBackend.Dal;
using EmployeeManagementFSApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementFSApiBackend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;


        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<EmployeeExt> GetAllEmployees()
        {
            var employees = (from emp in _context.Employees
                             join sta in _context.EStates on emp.emp_state equals sta.state_id
                             join cty in _context.Cities on emp.emp_city equals cty.city_id
                             join gnd in _context.Genders on emp.emp_gender equals gnd.gender_id
                             join dept in _context.Departments on emp.emp_dept equals dept.dept_id

                             where emp.emp_activeflag == "Y"

                             select new EmployeeExt
                             {
                                 emp_activeflag = emp.emp_activeflag,
                                 emp_id = emp.emp_id,
                                 emp_name = emp.emp_name,
                                 emp_phone = emp.emp_phone,
                                 emp_email = emp.emp_email,
                                 emp_city = emp.emp_city,
                                 emp_gender = emp.emp_gender,
                                 emp_dept = emp.emp_dept,
                                 emp_salary = emp.emp_salary,
                                 emp_state = emp.emp_state,
                                 state_name = sta.state_name,
                                 city_name = cty.city_name,
                                 gender_name = gnd.gender_name,
                                 dept_name = dept.dept_name,
                             }).ToList();
            return employees;
        }

        public async Task<EmployeeExt> GetEmployeeById(int id)
        {
            var employee = await (from emp in _context.Employees
                                  join sta in _context.EStates on emp.emp_state equals sta.state_id
                                  join cty in _context.Cities on emp.emp_city equals cty.city_id
                                  join gnd in _context.Genders on emp.emp_gender equals gnd.gender_id
                                  join dept in _context.Departments on emp.emp_dept equals dept.dept_id

                                  where emp.emp_activeflag == "Y" && emp.emp_id == id

                                  select new EmployeeExt
                                  {
                                      emp_activeflag = emp.emp_activeflag,
                                      emp_id = emp.emp_id,
                                      emp_name = emp.emp_name,
                                      emp_phone = emp.emp_phone,
                                      emp_email = emp.emp_email,
                                      emp_city = emp.emp_city,
                                      emp_gender = emp.emp_gender,
                                      emp_dept = emp.emp_dept,
                                      emp_salary = emp.emp_salary,
                                      emp_state = emp.emp_state,
                                      state_name = sta.state_name,
                                      city_name = cty.city_name,
                                      gender_name = gnd.gender_name,
                                      dept_name = dept.dept_name,
                                  }).FirstOrDefaultAsync();
            return employee;
        }

        public List<EState> GetAllStates()
        {
            var states = _context.EStates.ToList();
            return states;
        }

        public List<City> GetAllCitiesByStateId(int state_id)
        {
            var cities = _context.Cities.Where(e => e.state_id == state_id).Select(s => s).ToList();
            return cities;
        }

        public List<Department> GetAllDepartments()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public List<Gender> GetAllGenders()
        {
            var genders = _context.Genders.ToList();
            return genders;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var empExist = await _context.Employees.Where(e => e.emp_activeflag == "Y" && e.emp_id == id).Select(e => e).FirstOrDefaultAsync();
            if (empExist != null)
            {
                empExist.emp_activeflag = "N";
                _context.Employees.Update(empExist);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Employee> SaveEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var empExist = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.emp_id == employee.emp_id && e.emp_activeflag == "Y");
            if (empExist != null)
            {
                employee.emp_id = empExist.emp_id;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return employee.emp_id;
            }
            return 0 ;
        }
    }
}
