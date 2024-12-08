using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class UpdateAttendanceRequest
    {
        public int StudentId { get; set; }
        public int SubjectId {  get; set; }
        public DateOnly Date {  get; set; }
        public int LessonN {  get; set; }

    }
}
