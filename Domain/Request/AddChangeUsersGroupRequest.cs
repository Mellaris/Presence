using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class AddChangeUsersGroupRequest
    {
        public int GroupId { get; set; }
        public List<int> StudentsId { get; set; }
    }
}
