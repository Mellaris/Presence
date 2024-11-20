using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IStudentsRepository
    {
        public bool AddStudents(Students students);
    }
}
