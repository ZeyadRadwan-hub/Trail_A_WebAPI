using JobPortal.DTOs.Auth;
using JobPortal.Repo.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginDTO dto)
        {
            var token = await _unitOfWork.CustomAuth.Login(dto);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> Rigster([FromBody] AuthRigsterDTO dto)
        {
            var res = await _unitOfWork.CustomAuth.Rigster(dto);
            if(res == false)
                return BadRequest();

            return Ok("Registered");
        }
    }
}
