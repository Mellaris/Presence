using Data.DAO;
using Data.Repository;
using Domain.Entity;
using Domain.Request;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class AttendanceService : IAttendanceUseCase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public void AddAttendance(AddAttendanceRequest presence)
        {
            var students = new Students { Id = presence.StudentId };
            var status = new Statuses { Id = presence.StatusId };
            var sub = new Subjects { Id = presence.SubjectId };
            _attendanceRepository.AddAttendance(new Attendance
            {
                IdStudent = students,
                IdStatus = status,
                SubjectId = sub,
                LessonNumber = presence.LessonNumber,
            });
        }

        public IEnumerable<AttendanceEntity> GetAllAttendance()
        {
            return _attendanceRepository.GetAllAttendance().Select(presence => new AttendanceEntity
            {
                Student = new StudentEntity
                {
                    Guid = presence.IdStudent.Id,
                    Name = presence.IdStudent.Fio,
                    Group = new GroupEntity
                    {
                        Id = presence.IdStudent.IdGroup.Id,
                        Name = presence.IdStudent.IdGroup.Name
                    }
                },
                Status = new StatusEntity
                {
                    Id = presence.IdStatus.Id,
                    Name = presence.IdStatus.NameStatus,
                },
                Subject = new SubjectEntity
                {
                    Id = presence.SubjectId.Id,
                    Name = presence.SubjectId.Name,
                    GroupsSubject = presence.SubjectId.GroupsSubject.Select(subject => new GroupSubjectEntity
                    {
                        Semester = Convert.ToInt32(subject.Semestr),
                        Group = new GroupEntity()
                        {
                            Id = subject.GroupId.Id,
                            Name = subject.GroupId.Name
                        }
                    }).ToList(),
                },
                Date = presence.Date,
                LessonN = presence.LessonNumber,
                Id = presence.Id
            }).ToList();
        }

        public void RemoveAllAttendance()
        {
            _attendanceRepository.RemoveAllAttendance();
        }

        public void RemoveAttendanceByGroup(int Id)
        {
            _attendanceRepository.RemoveAttendanceGroup(Id);
        }

        public void UpdateAttendance(int Id, UpdateAttendanceRequest presence)
        {
            _attendanceRepository.UpdateAttendance(Id, new Attendance
            {
                Id = presence.AttendanceId
            });
        }
    }
}
