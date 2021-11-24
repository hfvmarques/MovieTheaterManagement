using MovieTheatherManagement.Domain;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Controllers.V1
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}