using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyService companyService, IMapper mapper, ICompanyRepository companyRepository)
        {
            _companyService = companyService;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = await _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Company data cannot be null.");
            }
            
            var company = _mapper.Map<Company>(companyDto);
            var result = await _companyRepository.SaveCompany(company);

            if (!result)
            {
                return BadRequest("Unable to save company.");
            }

            return Ok(company);
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> Put(string companyCode, [FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Company data cannot be null.");
            }

            var company = _mapper.Map<Company>(companyDto);
            company.CompanyCode = companyCode;
            var result = await _companyRepository.SaveCompany(company);

            if (!result)
            {
                return BadRequest("Unable to save company.");
            }

            return Ok(company);
        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(string companyCode)
        {
            var result = await _companyRepository.DeleteCompany(companyCode);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Company deleted successfully.");
        }
    }
}