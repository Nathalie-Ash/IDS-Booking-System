using AutoMapper;
using IDS.Core.Models;
using IDS.Services.Interfaces;
using IDSBookingSystem.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDSBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Choices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }

        // GET: api/Choices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            return Ok(company);
        }




        // PUT: api/Choices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            var companyToBeUpdate = await _companyService.GetCompanyById(id);

            if (companyToBeUpdate == null)
                return NotFound();

            await _companyService.UpdateCompany(companyToBeUpdate, company);

            var updatedCompany = await _companyService.GetCompanyById(id);

            return Ok(updatedCompany);
        }

        // POST: api/Choices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostChoice(Company newcompany)
        {
            var choice = await _companyService.CreateCompany(newcompany);
            return Ok(choice);
        }

        // DELETE: api/Choices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyService.DeleteCompany(company);

            return NoContent();
        }

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyService = companyService;
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CompanyResource>>> GetAllCompanies()
        {
            try
            {
                var companies = await _companyService.GetAllWithCompany();
                var companyResources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

                return Ok(companyResources);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, "An error occurred while retrieving music resources.");
            }
        }


    

    }
}
