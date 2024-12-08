using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IAttendanceRepository
    {
        public bool AddAttendance(Attendance attendance);
        public bool RemoveAttendanceGroup(int Id);
        public bool RemoveAllAttendance();
        public bool UpdateAttendance(int Id, Attendance attendance);
        public IEnumerable<Attendance> GetAllAttendance();
    }
}
