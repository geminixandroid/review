using SecondService.Models;
using System.Threading.Tasks;

namespace SecondService.Services
{
    public interface IOrganizationsService
    {
        public Task<int> SaveOrganization(Organization organization);
        public Task<int> UpdateUserOrganization(User user);
    }

}
