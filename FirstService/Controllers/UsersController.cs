using FirstService.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDTO;
using System.Threading.Tasks;

namespace FirstService.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {            
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<string> AddUser(UserDTO query)
        {
            return await _mediator.Send(new AddUserCommand() { UserDTO = query });
        }
    }
}
