using FluentValidation;
using MassTransit;
using MediatR;
using ServicesDTO;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FirstService.Commands
{
    public class AddUserCommand : IRequest<string>
    {
        public UserDTO UserDTO { get; set; }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
        {
            private readonly IBus _bus;
            private readonly IValidator<UserDTO> _validator;

            public AddUserCommandHandler(IBus bus, IValidator<UserDTO> validator)
            {
                _bus = bus ?? throw new ArgumentNullException();
                _validator = validator ?? throw new ArgumentNullException();
            }

            public async Task<string> Handle(AddUserCommand command, CancellationToken cancellationToken=default)
            {
                var validationResult=_validator.Validate(command.UserDTO);
                if (validationResult.IsValid)
                {
                    await _bus.Publish(command.UserDTO);
                    return $"Запрос на добавление отправлен {JsonSerializer.Serialize(command.UserDTO)}";
                }
                else {
                    return $"Запрос на добавление отклонен {JsonSerializer.Serialize(validationResult.Errors)}";
                }
            }
        }

    }
}
