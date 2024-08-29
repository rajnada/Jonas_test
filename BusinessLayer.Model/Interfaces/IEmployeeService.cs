using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployInfo>> GetAllEmployeesAsync();
        Task<EmployInfo> GetEmployeeByCodeAsync(string employeeCode);
       
    }
}
