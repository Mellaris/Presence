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
    }
}
