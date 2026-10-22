using AutoMapper;
using JobPortal.Data;
using JobPortal.DTOs.Job;
using JobPortal.Repo.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trail_A.Models;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Third-Highest-Salary")]
        public async Task<IActionResult> GetThird()
        {
            var get = await _unitOfWork.CustomJob.GetThirdHighestSalary();
            var map = _mapper.Map<JobResponeDTO>(get);
            return Ok(map);
        }

        [HttpGet("Get-By_Id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await _unitOfWork.CustomJob.GetById(id);
            var map = _mapper.Map<JobResponeGetByIdDTO>(get);
            return Ok(map);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                _unitOfWork.Job.Delete(id);
                await _unitOfWork.SaveAsync();
                return Ok("Job deleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest("Cannot delete this job because it has applications");
            }
        }

        [HttpGet("{KeyWord:alpha}")]
        public async Task<List<JobResponeDTO>> Search(string KeyWord)
        {
            var get = await _unitOfWork.CustomJob.Search(KeyWord);
            var map = _mapper.Map<List<JobResponeDTO>>(get);
            return map;
        }
    }
}
