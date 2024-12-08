using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class AttendanceEntity
    {
        public int Id { get; set; }
        public virtual StudentEntity Student { get; set; }
        public virtual SubjectEntity Subject { get; set; }
        public StatusEntity Status { get; set; }
        public DateOnly Date { get; set; }
        public int LessonN { get; set; }

    }
}
