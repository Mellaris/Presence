using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ISubjectRepository
    {
        public bool AddSubject(Subjects subject);
        public bool RemoveSubject(int Id);
        public bool UpdateSubject(int Id, Subjects subject);
        public IEnumerable<Subjects> GetAllSubject();

        public Subjects GetSubject(int Id);


    }
}
