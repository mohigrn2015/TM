using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.BLL.BLLInterface
{
    public interface IBLLRoleManage
    {
        long RoleAssignToUser(RoleManageRequest model);
        long RoleManage(RoleManageRequest model);
        List<RoleMangeResponseModel> GetFeatureList(RoleManageRequest model);
        List<AssignedRoleResponseModel> GetActiveFeatures(RoleManageRequest model);

    }
} 
