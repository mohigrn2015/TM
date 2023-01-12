using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Response.Entity
{
    public class ValidateUser
    {
        public int userId { get; set; }
        public string session_token { get; set; }
        public int rightid { get; set; } 
        public int roleid { get; set; }
        public string right_name { get; set; }
        public string role_name { get; set; }
        public string user_name { get; set; }
        public string device_Id { get; set; } 
        public int is_success { get; set; }
        public string serverName { get; set; } 
        public string teamId { get; set; }
    }
}
