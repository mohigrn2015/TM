using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Request.Entity
{
    public class TaskManageReq : CommonRequestModel
    {
        public int taskid { get; set; } 
        public string cr_id { get; set; }
        public string cr_name { get; set; }
        public string taskname { get; set; }
        public string description { get; set; }
        public int is_active { get; set; } 
        public int userId { get; set; }
    }
}
