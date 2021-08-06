using SecondService.Models;
using SecondService.Queries;
using System.Threading.Tasks;

namespace SecondService.Services
{
    public interface IUsersService
    {
        public Task<int> SaveUser(User user);
        public Task<Pagination<User>> GetPageOfUsersByOrganizationId(GetPageOfUsersByOrganizationIdQuery query);
    }
}
