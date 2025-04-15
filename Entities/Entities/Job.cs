using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Job
    {
        public int JobID { get; set; }
        public string JobName { get; set; }  


        public virtual User? User { get; set; }
        public int UserID { get; set; }
    }
}
