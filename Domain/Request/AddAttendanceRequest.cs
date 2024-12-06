using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class AddAttendanceRequest
    {
        public int StudentId { get; set; }
        public int StatusId { get; set; }
        public int SubjectId { get; set; }
        public int LessonNumber { get; set; }
        public DateOnly Date {  get; set; }
    }
}
