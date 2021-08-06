using AutoMapper;
using ServicesDTO;
using System.Collections.Generic;

namespace SecondService.Models.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();
            CreateMap< Pagination<User>, UsersPageByOrganizationDto>();          
            CreateMap<UsersPageByOrganizationDto, Pagination<User>>();          
        }
    }
}
