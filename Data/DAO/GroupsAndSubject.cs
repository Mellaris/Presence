using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class GroupsAndSubject
    {
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string GroupId { get; set; }
        public string Semestr {  get; set; }
    }
}
