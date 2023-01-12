using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DAL.DALInterface;
using TM.DAL.DALUtility;
using TM.DAL.Parameters;
using TM.Entity;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.DAL.Repository
{
    internal class RoleMangeRepository : IDALRoleManage
    {
        LogsHandler _logsHandler = new LogsHandler();
        DynamicParams _dynamic = new DynamicParams();

        public List<AssignedRoleResponseModel> GetActiveFeatures(RoleManageRequest model)
        {
            List<AssignedRoleResponseModel> features = new List<AssignedRoleResponseModel>();
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<AssignedRoleResponseModel>("UG_GET_ACTIVE_FEATURE", _dynamic.SetParametersGetActiveFeature(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        features = attemp.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return features;
        }

        public List<UserResponseModel> GetAllUsers(CommonRequestModel model)
        {
            List<UserResponseModel> users = new List<UserResponseModel>();
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<UserResponseModel>("UG_GET_USER_LIST", _dynamic.SetParametersGetUsers(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        users = attemp.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return users;
        }

        public List<RoleMangeResponseModel> GetFeturesList(RoleManageRequest model)
        {
            List<RoleMangeResponseModel> roles = new List<RoleMangeResponseModel>();
            _dynamic = new DynamicParams(); 
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<RoleMangeResponseModel>("UG_GET_FEATURE_LIST", _dynamic.SetParametersGetFeature(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        roles = attemp.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return roles;
        }

        public long RoleAssignToUser(RoleManageRequest model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<long>("US_USER_ROLE_ASSIGN", _dynamic.SetParametersRoleAssign(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp);
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }

        public long RoleManage(RoleManageRequest model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<long>("US_USER_ROLE_MANGAE", _dynamic.SetParametersRoleMangae(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp);
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }
    }
}
