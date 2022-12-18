using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.DAL.DALInterface
{
    public interface IDALRoleManage
    {
        long RoleAssignToUser(RoleManageRequest model);
        long RoleManage(RoleManageRequest model); 
        List<RoleMangeResponseModel> GetFeturesList(RoleManageRequest model);
        List<AssignedRoleResponseModel> GetActiveFeatures(RoleManageRequest model);

    }
}
