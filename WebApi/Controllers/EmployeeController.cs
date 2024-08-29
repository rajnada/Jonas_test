using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using Ninject;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        // GET api/employee
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        // GET api/employee/5
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            var employee = await _employeeService.GetEmployeeByCodeAsync(employeeCode);
            return _mapper.Map<EmployeeDto>(employee);
        }

        // POST api/employee
        public async Task<IHttpActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data cannot be null.");
            }
            
            var employeeInfo = _mapper.Map<EmployInfo>(employeeDto);
            var employee = _mapper.Map<Employee>(employeeInfo);
            var result = await _employeeRepository.SaveEmployeeAsync(employee);

            if (!result)
            {
                return BadRequest("Unable to save employee.");
            }

            return Ok("Employee added/updated successfully.");
        }

        // DELETE api/employee/5
        public async Task<IHttpActionResult> Delete(string employeeCode)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(employeeCode);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Employee deleted successfully.");
        }
    }
}
