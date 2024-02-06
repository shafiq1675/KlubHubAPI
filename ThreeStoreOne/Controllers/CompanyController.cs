using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        public readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        
        [HttpGet("GetCompanies")]
        public IEnumerable<Company> GetCompanies()
        {
            return _companyService.GetAllCompany().ToArray();
        }

        [HttpPost]
        public IActionResult Post(Company company)
        {
            this._companyService.AddCompany(company);
            return Ok();
        }
    }
}
