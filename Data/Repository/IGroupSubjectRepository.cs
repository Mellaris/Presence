using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGroupSubjectRepository
    {
        public bool AddGroupSubject(GroupsAndSubject groupSubject);
        public bool RemoveGroupSubject(GroupsAndSubject groupSubject);
    }
}
