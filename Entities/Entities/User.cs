using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }  
        public string UserLastName { get; set; }  

        public List<Job> Jobs { get; set; } = new List<Job>(); 
    }
}
