using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGroupRepository
    {
        public IEnumerable<Groups> GetAllGroup();
        public bool AddGroup(Groups groups);
        public bool RemoveGroup(Groups groups);
        public bool UpdateGroup(int Id, Groups groups); 
        public bool addGroupWithStudents(Groups groups, IEnumerable<Students> students);
    }
}
