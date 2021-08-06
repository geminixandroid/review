using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SecondService.Commands;
using ServicesDTO;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecondService.Consumers
{
    public class ConsumerUser : IConsumer<UserDTO>
    {
        readonly ILogger<ConsumerUser> _logger;
        readonly IMediator _mediator;

        public ConsumerUser(ILogger<ConsumerUser> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException();
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        public async Task Consume(ConsumeContext<UserDTO> context)
        {
            _logger.LogInformation("Пришло сообщение о добавлении User: {Text}", JsonSerializer.Serialize(context.Message));
            var newUserId=await _mediator.Send(new AddUserCommand() { UserDTO = context.Message });
            _logger.LogInformation("Добавлен User: {Text}", newUserId);               
        }
    }
}
