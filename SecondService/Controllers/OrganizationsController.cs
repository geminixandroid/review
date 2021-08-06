using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondService.Commands;
using SecondService.Queries;
using ServicesDTO;
using System.Threading.Tasks;

namespace SecondService.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly ILogger<OrganizationsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrganizationsController(ILogger<OrganizationsController> logger, IMapper mapper, IMediator mediator)
        {            
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("updateuserorganization")]
        public async Task<int> UpdateUserOrganization(UserDTO query)
        {
            return await _mediator.Send(new AddUserToOrganizationCommand() { UserDTO = query });           
        }
        [Route("pagination")]
        [HttpPost]
        public async Task<UsersPageByOrganizationDto> GetOrganizationPage(GetPageOfUsersByOrganizationIdQuery query)
        {
            return await _mediator.Send(new GetPageOfUsersByOrganizationIdCommand() {GetPageOfOrganizationBuyIdQuery=query } );
        }
    }
}
