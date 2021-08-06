using SecondService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SecondService.Services
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly ApplicationDBContext _applicationContext;
        public OrganizationsService(ApplicationDBContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<int> SaveOrganization(Organization organization)
        {
            _applicationContext.Organizations.Add(organization);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUserOrganization(User user)
        {
            var findedUser = _applicationContext.Users.FirstOrDefault(x => x.UserId == user.UserId);
            var findedOrganization = _applicationContext.Organizations.FirstOrDefault(x => x.OrganizationId == user.OrganizationId);
            findedUser.OrganizationId = findedOrganization.OrganizationId;
            _applicationContext.Users.Update(findedUser);
            return await _applicationContext.SaveChangesAsync();
        }

    }

}
