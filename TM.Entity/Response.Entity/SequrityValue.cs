using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Response.Entity
{
    public class SequrityValue
    {
        public string loginProvider { get; set; }
        public int userId { get; set; }
        public int rightId { get; set; }
        public string rightName { get; set; } 
        public string userName { get; set; }
        public int roleid { get; set; }
        public string roleName { get; set; } 
        public int isSessionValid { get; set; }
        public int teamId { get; set; }
    }
}
