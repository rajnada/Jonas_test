using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployInfo>> GetAllEmployeesAsync()
        {
            var res =  await _employeeRepository.GetAllEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployInfo>>(res);
        }

        public async Task<EmployInfo> GetEmployeeByCodeAsync(string employeeCode)
        {
            var res = await _employeeRepository.GetEmployeeByCodeAsync(employeeCode);
            return _mapper.Map<EmployInfo>(res);
        }

      
    }
}


