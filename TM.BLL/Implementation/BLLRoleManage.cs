using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.BLL.BLLInterface;
using TM.DAL.DALInterface;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.BLL.Implementation
{
    internal class BLLRoleManage : IBLLRoleManage
    {
        private IDALRoleManage _dALRoleManage;
        public BLLRoleManage(IDALRoleManage roleManage)
        {
            _dALRoleManage = roleManage;     
        }

        public List<AssignedRoleResponseModel> GetActiveFeatures(RoleManageRequest model)
        {
            List<AssignedRoleResponseModel> actFeatures = new List<AssignedRoleResponseModel>();
            try
            {
                actFeatures = _dALRoleManage.GetActiveFeatures(model);  
            }
            catch (Exception)
            {
                throw;
            }
            return actFeatures;
        }

        public List<UserResponseModel> GetAllUsers(CommonRequestModel model)
        {
            List<UserResponseModel> users = new List<UserResponseModel>();
            try
            {
                users = _dALRoleManage.GetAllUsers(model);
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        public List<RoleMangeResponseModel> GetFeatureList(RoleManageRequest model)
        {
            List<RoleMangeResponseModel> roleMangeResponse = new List<RoleMangeResponseModel>();   
            try
            {
                roleMangeResponse = _dALRoleManage.GetFeturesList(model);
            }
            catch (Exception)
            {
                throw;
            }
            return roleMangeResponse;
        }

        public long RoleAssignToUser(RoleManageRequest model)
        {
            long roleAssignToUser = 0;  
            try
            {
                foreach (int item in model.featureList)
                {
                    model.feature_id = item;
                    roleAssignToUser = _dALRoleManage.RoleAssignToUser(model);
                }                
            }
            catch (Exception)
            {
                throw;
            }
            return roleAssignToUser;
        }

        public long RoleManage(RoleManageRequest model)
        { 
            long roleManage = 0;
            try
            {
                foreach (int item in model.featureList) 
                {
                    model.feature_id = item;
                    roleManage = _dALRoleManage.RoleManage(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return roleManage;  
        }
    }
}
