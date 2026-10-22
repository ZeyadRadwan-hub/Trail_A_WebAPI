using JobPortal.DTOs.Auth;

namespace JobPortal.Repo.Contract
{
    public interface IAuthRepo
    {
        Task<string> Login(AuthLoginDTO dto);
        Task<bool> Rigster(AuthRigsterDTO dto);
    }
}
