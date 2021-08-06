using AutoMapper;
using MediatR;
using SecondService.Queries;
using SecondService.Services;
using ServicesDTO;
using System.Threading;
using System.Threading.Tasks;

namespace SecondService.Commands
{
    public class GetPageOfUsersByOrganizationIdCommand : IRequest<UsersPageByOrganizationDto>
    {
        public GetPageOfUsersByOrganizationIdQuery GetPageOfOrganizationBuyIdQuery { get; set; }

        public class GetOrganizationPageHandler : IRequestHandler<GetPageOfUsersByOrganizationIdCommand, UsersPageByOrganizationDto>
        {
            private readonly IUsersService _usersService;
            private readonly IMapper _mapper;


            public GetOrganizationPageHandler(IUsersService usersService, IMapper mapper)
            {
                _usersService = usersService;
                _mapper = mapper;
            }

            public async Task<UsersPageByOrganizationDto> Handle(GetPageOfUsersByOrganizationIdCommand command, CancellationToken cancellationToken=default)
            {
                var result= await _usersService.GetPageOfUsersByOrganizationId(command.GetPageOfOrganizationBuyIdQuery);
                return _mapper.Map<UsersPageByOrganizationDto>(result);
            }
        }
    }
}
