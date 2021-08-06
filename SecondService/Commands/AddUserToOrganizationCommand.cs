using AutoMapper;
using MassTransit;
using MediatR;
using SecondService.Models;
using SecondService.Services;
using ServicesDTO;
using System.Threading;
using System.Threading.Tasks;

namespace SecondService.Commands
{
    public class AddUserToOrganizationCommand : IRequest<int>
    {
        public UserDTO UserDTO { get; set; }

        public class AddUserToOrganizationHandler : IRequestHandler<AddUserToOrganizationCommand, int>
        {
            private readonly IOrganizationsService _organizationsService;
            private readonly IMapper _mapper;

            public AddUserToOrganizationHandler(IOrganizationsService organizationsService, IMapper mapper)
            {
                _organizationsService = organizationsService;
                _mapper = mapper;
            }

            public async Task<int> Handle(AddUserToOrganizationCommand command, CancellationToken cancellationToken=default)
            {
                return await _organizationsService.UpdateUserOrganization(_mapper.Map<User>(command.UserDTO));
            }
        }
    }
}
