using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeDbWrapper.FindAllAsync();
        }

        public async Task<Employee> GetEmployeeByCodeAsync(string employeeCode)
        {
            var result = await _employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(employeeCode));
            return result.FirstOrDefault();
        }

        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _employeeDbWrapper.FindAsync(t =>
                t.SiteId.Equals(employee.SiteId) && t.CompanyCode.Equals(employee.CompanyCode) && t.EmployeeCode.Equals(employee.EmployeeCode));

            var employeeToSave = existingEmployee.FirstOrDefault();

            if (employeeToSave != null)
            {
                employeeToSave.EmployeeName = employee.EmployeeName;
                employeeToSave.Occupation = employee.Occupation;
                employeeToSave.EmployeeStatus = employee.EmployeeStatus;
                employeeToSave.EmailAddress = employee.EmailAddress;
                employeeToSave.Phone = employee.Phone;
                employeeToSave.LastModified = employee.LastModified;

                return await _employeeDbWrapper.UpdateAsync(employeeToSave);
            }

            return await _employeeDbWrapper.InsertAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(string employeeCode)
        {
            return await _employeeDbWrapper.DeleteAsync(t => t.EmployeeCode.Equals(employeeCode));
        }
    }
}
