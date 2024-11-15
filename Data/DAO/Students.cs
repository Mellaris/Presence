using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string Fio { get; set; }
        public virtual Groups IdGroup { get; set; }
    }
}
