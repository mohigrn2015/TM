using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Response.Entity
{
    public class TasksResponses
    {
        public string taskid { get; set; }
        public string cr_id { get; set; }
        public string cr_name { get; set; }
        public string taskname { get; set; }
        public string description { get; set; }
        public int is_active { get; set; }
        public string created_date { get; set; }
        public string created_by { get; set; }
        public int userId { get; set; }
    }
}
 