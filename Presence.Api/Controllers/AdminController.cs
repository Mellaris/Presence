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
        public ActionResult<StudentResponse> GetAllStudents()
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
        [HttpPost(template: "User/{name}")]
        public ActionResult<StudentResponse> AddStudent(StudentRequest user)
        {
            _userService.AddStudents(new AddStudentsRequest { Name = user.Name });
            return Ok();
        }
        [HttpDelete(template: "User/{guid}")]
        public ActionResult<StudentResponse> RemoveUser(int guid)
        {
            _userService.RemoveStudents(new RemoveStudentsRequest { idS = guid });
            return Ok();
        }
        //[HttpPost(template: "group/{group_id}/subjects")]
        //public ActionResult<SubjectResponse> AddSubject(Groups group_id, List<SubjectRequest> subjects)
        //{
        //    _gsService.AddGroupSubject(new AddGroupSubjectsRequest
        //    {
        //        GroupId = group_id,
        //        subjects = subjects
        //        .Select(subject => new Semestrs { SubjectId = subject.Id, Semestr = subject.Semestr }).ToList()
        //    });
        //    return Ok();
        //}
    }
}
