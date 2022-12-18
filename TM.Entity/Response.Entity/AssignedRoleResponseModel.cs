using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Response.Entity
{
    public class AssignedRoleResponseModel : CommonResponseModel
    {
        public int feature_id { get; set; }
        public string role_name { get; set; }
        public string feature_name { get; set; }
        public int is_active { get; set; } 
    } 
}
