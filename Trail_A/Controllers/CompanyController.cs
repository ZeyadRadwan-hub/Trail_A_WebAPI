using AutoMapper;
using JobPortal.DTOs.Company;
using JobPortal.Repo.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Most-Jobs")]
        public async Task<IActionResult> Get()
        {
            var get = await _unitOfWork.CustomCompany.GetGreatest();
            var map = _mapper.Map<CompanyResponeDTO>(get);
            return Ok(map);
        }
    }
}
