using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Request.Entity
{
    public class TeamRequestModel : CommonRequestModel
    {
        public string team_name { get; set; }
        public string team_type { get; set; }
    }
}
 