using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class Semestrs
    {
        public Subjects SubjectId { get; set; }
        public int Semestr { get; set; }
    }
}
