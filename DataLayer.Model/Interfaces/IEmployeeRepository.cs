﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByCodeAsync(string employeeCode);
        Task<bool> SaveEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(string employeeCode);
    }
}
