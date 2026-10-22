using JobPortal.Data;
using JobPortal.DTOs.Auth;
using JobPortal.Repo.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trail_A.Models;

namespace JobPortal.Repo.Implementation
{
    public class AuthRepo:IAuthRepo
    {
        private readonly IConfiguration _configuration;
        private readonly App_Database_Context _db;

        public AuthRepo(IConfiguration configuration, App_Database_Context db)
        {
            _configuration = configuration;
            _db = db;
        }

        public async Task<string> Login(AuthLoginDTO dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
                return null;
            if (user.Password == dto.Password)
                return GeneratToken(user);

            return null;
        }

        public async Task<bool> Rigster(AuthRigsterDTO dto)
        {
            var ExisitingEmail = await _db.Users.AnyAsync(x => x.Email == dto.Email);
            if(ExisitingEmail==true) 
                return false;

            var NewUser = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                FullName = dto.FullName
            };

            await _db.Users.AddAsync(NewUser);
            await _db.SaveChangesAsync();
            return true;
        }
        private string GeneratToken(User user)
        {
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWt:Key"]));
            var SigningCrend = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var JWTTOKEN = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audciene"],
                expires: DateTime.Now.AddDays(Convert.ToDouble(_configuration["JWT:ExpierInHours"])),
                signingCredentials: SigningCrend,
                claims:Claims
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWTTOKEN);
            return token;
        }
    }
}
