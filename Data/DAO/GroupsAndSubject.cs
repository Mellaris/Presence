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
        public virtual Subjects SubjectId { get; set; }
        //public virtual int idSub { get; set; }
        public virtual Groups GroupId { get; set; }
        public string Semestr {  get; set; }
    }
}
