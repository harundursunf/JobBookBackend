using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }  
        public string UserLastName { get; set; }  

        public List<JobDTO> Jobs { get; set; } = new List<JobDTO>(); 
    }
}
