using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public virtual Statuses IdStatus { get; set; }
        public DateOnly Date {  get; set; }
        public int LessonNumber { get; set; }
        public int IdStudent { get; set; }
    }
}
