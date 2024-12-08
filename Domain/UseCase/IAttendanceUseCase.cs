using Domain.Entity;
using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IAttendanceUseCase
    {
        public void AddAttendance(AddAttendanceRequest presence);
        public void RemoveAttendanceByGroup(int Id);
        public void RemoveAllAttendance();
        public void UpdateAttendance(int Id, UpdateAttendanceRequest presence);
        public IEnumerable<AttendanceEntity> GetAllAttendance();
    }
}
