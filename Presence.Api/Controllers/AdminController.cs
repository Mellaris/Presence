using Data.DAO;
using Domain.Request;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Request;
using Presence.Api.Response;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IStudentsUseCase _userService;
        private readonly ISubjectUseCase _subjectService;
        private readonly IGroupSubsUseCase _gsService;

        public AdminController(ISubjectUseCase subjectService, IStudentsUseCase userService, IGroupSubsUseCase gsService)
        {
            _subjectService = subjectService;
            _userService = userService;
            _gsService = gsService;
        }
        [HttpGet(template: "users")]
        public ActionResult<StudentResponse> GetAllUsers()
        {
            var result = _userService.GetAllUsers()
                .Select(user => new StudentResponse
                {
                    Guid = user.Guid,
                    Name = user.Name,
                    Group = new GroupResponse { Name = user.Group.Name }
                }).ToList();
            return Ok(result);
        }
        [HttpPost(template: "{group_id}/students")]
        public ActionResult<StudentResponse> AddUser(int group_id, List<int> student_id)
        {
            _userService.AddChangeUsersGroup(new AddChangeUsersGroupRequest { GroupId = group_id, StudentsId = student_id.Select(guid => (guid)).ToList() });
            return Ok();
        }
        [HttpPost(template: "group/{group_id}/subjects")]
        public ActionResult<SubjectResponse> AddSubject(int group_id, List<SubjectRequest> subjects)
        {
            var group = new Groups { Id = group_id };
            _gsService.AddGroupSubject(new AddGroupSubjectsRequest
            {
                GroupId = group,
                subjects = subjects
                .Select(subject => new Semestrs { SubjectId = subject.Id, Semestr = subject.Semestr }).ToList()
            });
            return Ok();
        }
    }
}
