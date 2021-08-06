using System.Collections.Generic;

namespace ServicesDTO
{
    public class UsersPageByOrganizationDto
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public IEnumerable<UserDTO> Items { get; set; }
    }
}
