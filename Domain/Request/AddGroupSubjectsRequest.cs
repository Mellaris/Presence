using Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class AddGroupSubjectsRequest
    {
        public Groups GroupId { get; set; }
        public List<Semestrs> subjects { get; set; }

    }
}
