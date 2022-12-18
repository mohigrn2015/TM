using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Request.Entity
{
    public class RoleManageRequest : CommonRequestModel
    {
        public List<int> featureList { get; set; }
        public int right_userId { get; set; }
        public int user_roleId { get; set; } 
        public int feature_id { get; set; }


    }
}
