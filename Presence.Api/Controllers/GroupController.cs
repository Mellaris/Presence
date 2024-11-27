using Data.DAO;
using Domain.Service;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupUseCase _groupService;
        public GroupController(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }
        [HttpGet("/groups")]
        public ActionResult<GroupResponse> GetAllGroups()
        {
           var result = _groupService
                .GetGroupsWithStudents()
                .Select(group => new GroupResponse {
                    Id = group.Id,
                    Name = group.Name,
                    Students = (IEnumerable<StudentResponse>)group.Students?.Select(
                        user => new StudentResponse
                        {
                            Guid = user.Guid,
                            Name = user.Name,
                        }).ToList(),
                }).ToList();
            return Ok(result);

        }
    }
}
