using Data.DAO;
using Domain.Entity;
using Domain.Request;
using Domain.Service;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;
using Presence.Api.Request;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupUseCase _groupService;
        public GroupController(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public ActionResult<GroupResponse> GetAllGroup()
        {
            var result = _groupService.GetGroupsWithStudents().Select(group => new GroupResponse
            {
                Id = group.Id,
                Name = group.Name,
                Students = group.Students?.Select(user => new StudentResponse
                { Name = user.Name, Guid = user.Guid }).ToList()
            }).ToList();
            return Ok(result);
        }
        [HttpGet(template: "{Id}")]
        public ActionResult<GroupResponse> GetAllGroups(int Id)
        {
            GroupEntity group = _groupService.GetGroup(Id);
            var result = new GroupResponse
            {
                Id = group.Id,
                Name = group.Name,
                Students = (IEnumerable<StudentResponse>)group.Students
            .Select(user => new StudentResponse
            {
                Guid = user.Guid,
                Name = user.Name,
            })
            };
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<GroupResponse> AddGroup(GroupRequest group)
        {
            try
            {
                _groupService.AddGroupes(new AddGroupRequest { Name = group.Name });
            }
            catch
            {
                return Conflict();
            }
            return Ok();
        }
        [HttpPost(template: "{name}/{students}")]
        public ActionResult<GroupResponse> AddGroupWithStudents(GroupStudentsRequest group)
        {
            try
            {
                _groupService.AddGroupWithStudents(new AddGroupWithStudentRequest
                {
                    addGroupRequest = new AddGroupRequest { Name = group.Name },
                    AddStudentRequest = group.Students.Select(user => new AddStudentRequest { StudentName = user.Name }).ToList()
                });
            }
            catch
            {
                return Conflict();
            }
            return Ok();
        }
        [HttpDelete(template: "{Id}")]
        public ActionResult<GroupResponse> RemoveGroup(int Id)
        {
            _groupService.RemoveGroupes(new RemoveGroupRequest { Id = Id });
            return Ok();
        }
    }
}
