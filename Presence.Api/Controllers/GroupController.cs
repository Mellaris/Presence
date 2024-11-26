using Domain.Service;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupUseCase _groupService;
        public GroupController(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public ActionResult<GroupResponse> GetAllGroups()
        {
            _groupService.
            return Ok(new GroupResponse());

        }
    }
}
