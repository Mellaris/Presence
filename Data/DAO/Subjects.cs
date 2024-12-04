using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class Subjects
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<GroupsAndSubject> GroupsSubject { get; set; }
    }
}
