using Domain.Request;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Request;
using Presence.Api.Response;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceUseCase _attendanceService;
        public AttendanceController(IAttendanceUseCase attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet(template: "getPrecense")]
        public ActionResult<AttendanceResponse> GetPrecense()
        {
            var result = _attendanceService.GetAllAttendance().Select(presence => new AttendanceResponse
            {
                Student = new StudentResponse
                {
                    Guid = presence.Student.Guid,
                    Name = presence.Student.Name,
                    Group = new GroupResponse
                    {
                        Id = presence.Student.Group.Id,
                        Name = presence.Student.Group.Name
                    }
                },
                Status = new StatusResponse
                {
                    Id = presence.Status.Id,
                    Name = presence.Status.Name,
                },

                Subject = new SubjectResponse
                {
                    Id = presence.Subject.Id,
                    SubjectName = presence.Subject.Name,
                    groupSubjects = presence.Subject.GroupsSubject.Select(subject => new GroupSubjectResponse
                    {
                        Semestr = subject.Semester,
                        Group = new GroupResponse()
                        {
                            Id = subject.Group.Id,
                            Name = subject.Group.Name
                        }
                    }).ToList(),
                },
                Date = presence.Date,
                LessonN = presence.LessonN,
                Id = presence.Id

            }).ToList();

            return Ok(result);
        }

        [HttpPost(template: "presence")]
        public ActionResult<AttendanceResponse> AddAttendance(AttendanceRequest presence)
        {
            _attendanceService.AddAttendance(new AddAttendanceRequest
            {
                StatusId = presence.StatusId,
                SubjectId = presence.Id,
                StudentId = presence.StudentId,
            });
            return Ok();
        }
        [HttpDelete(template: "allPresence")]
        public ActionResult<AttendanceResponse> RemoveAllPresence()
        {
            _attendanceService.RemoveAllAttendance();
            return Ok();
        }
        [HttpDelete(template: "{group_id}")]
        public ActionResult<AttendanceResponse> RemovePresenceByGroupId(int group_id)
        {
            _attendanceService.RemoveAttendanceByGroup(group_id);
            return Ok();
        }
        [HttpPut(template: "presence/{status_id}")]
        public ActionResult<AttendanceResponse> UpdatePresenceStatus(int status_id, UpdateAttendanceRequest presence)
        {
            _attendanceService.UpdateAttendance(status_id, new UpdateAttendanceRequest { SubjectId = presence.SubjectId, StudentId = presence.StudentId });
            return Ok();
        }
    }
}
