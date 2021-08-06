using SecondService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SecondService.Queries;
using System.Linq;
using System;

namespace SecondService.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDBContext _applicationContext;

        public UsersService(ApplicationDBContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<int> SaveUser(User user)
        {
            _applicationContext.Users.Add(user);
            await _applicationContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<Pagination<User>> GetPageOfUsersByOrganizationId(GetPageOfUsersByOrganizationIdQuery query)
        {
            int pageSize = 3;
            IQueryable<User> source = _applicationContext.Users.Where(x => x.OrganizationId == query.OrganizationId);
            var count = await source.CountAsync();
            var TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            var items = await source.Skip((query.PageNumer - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<User>() { Page = query.PageNumer, Pages = TotalPages, Items = items };
        }
    }
}
