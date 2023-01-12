using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Request.Entity
{
    public class CommonRequestModel
    {
        public int RightId { get; set; }
        public int? TeamId { get; set; }
        public string Session_Token { get; set; }
        public int userId { get; set; }
    } 
} 

