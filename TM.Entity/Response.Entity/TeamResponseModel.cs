using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Response.Entity
{
    public class TeamResponseModel : CommonResponseModel
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        public string team_type { get; set; }
    }
}
 