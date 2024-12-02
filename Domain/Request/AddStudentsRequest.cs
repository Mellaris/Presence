using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class AddStudentsRequest
    {
        public string Name { get; set; }
        public Groups GroupId { get; set; }
    }
}
