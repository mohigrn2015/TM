using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    public class SecurityBase : ISecurityBase
    {
        LogsHandler _logsHandler = new LogsHandler();
        DynamicParams _dynamic = new DynamicParams();
        public long SaveEmployee(UserRegistration model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<UserRegistration>("US_ADD_EMPLOYEES", _dynamic.SetParametersInsertEmployee(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp.SingleOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }

        public long SaveLoginInfo(UserLoginAttempts attempts)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var attemp = constr.Query<UserLoginAttempts>("US_ADD_LOGIN_ATTEMPTS", _dynamic.SetParametersLoginAttempts(attempts), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp.SingleOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }

        public int ValidateSessionToken(TokenValidationRequest model)
        {
            DynamicParams _dynamic = new DynamicParams();
            int isValidToken = 0;
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var attemp = constr.Query<SequrityValue>("UG_VALIDATE_SESSIONTOKEN", _dynamic.TokenValidate(model.tokenProviderId, model.userId), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        foreach (var item in attemp)
                        {
                            isValidToken = Convert.ToInt16(item.isSessionValid);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isValidToken;
        }

        public ValidateUser ValidateUser(string user_name, string encPassword)
        {
            ValidateUser userModel = new Entity.Response.Entity.ValidateUser();
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var validateData = constr.Query<ValidateUser>("UG_VALIDATE_USER", _dynamic.ValidateUserCredential(user_name, encPassword), commandType: CommandType.StoredProcedure);

                    if (validateData != null && validateData.Count() > 0)
                    {
                        userModel = validateData.First();
                        userModel.is_success = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler = new LogsHandler();
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }

            return userModel;
        }
    }
}
