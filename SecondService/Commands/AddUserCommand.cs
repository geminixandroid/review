using AutoMapper;
using MediatR;
using SecondService.Models;
using SecondService.Services;
using ServicesDTO;
using System.Threading;
using System.Threading.Tasks;

namespace SecondService.Commands
{
    public class AddUserCommand : IRequest<int>
    {
        public UserDTO UserDTO { get; set; }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
        {
            private readonly IUsersService _usersService;
            private readonly IMapper _mapper;

            public AddUserCommandHandler(IUsersService usersService, IMapper mapper)
            {
                _usersService = usersService;
                _mapper = mapper;
            }

            public async Task<int> Handle(AddUserCommand command, CancellationToken cancellationToken=default)
            {
                return await _usersService.SaveUser(_mapper.Map<User>(command.UserDTO));
            }
        }
    }
}
