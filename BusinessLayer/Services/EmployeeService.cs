using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByCodeAsync(string employeeCode)
        {
            return await _employeeRepository.GetEmployeeByCodeAsync(employeeCode);
        }

        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.SaveEmployeeAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(string employeeCode)
        {
            return await _employeeRepository.DeleteEmployeeAsync(employeeCode);
        }
    }
}
