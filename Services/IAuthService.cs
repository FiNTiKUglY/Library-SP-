using Library.Models;
using Library.ViewModels;
using Library.Responses;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IAuthService
    {
        IEnumerable<User> Users { get; }
        public Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel user);
        public Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel user);
    }
}
