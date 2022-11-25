using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DAL.DALUtility;
using TM.Entity.Request.Entity;

namespace TM.DAL.Parameters
{
    internal class DynamicParams
    {
        LogsHandler _logsHandler = new LogsHandler();
        public DynamicParameters ValidateUserCredential(string userName, string password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@USER_NAME", userName);
            parameters.Add("@PASSWORD", password);
            return parameters;
        }
        public DynamicParameters SetParametersLoginAttempts(UserLoginAttempts attempts)
        {
            DynamicParameters parameters = new DynamicParameters();
            try 
            {
                parameters.Add("@USER_ID", attempts.userId);
                parameters.Add("@LOGIN_PROVIDER", attempts.loginProvider);
                parameters.Add("@DEVICE_ID", attempts.deviceId);
                parameters.Add("@IP_ADDRESS", attempts.ip_address);
                parameters.Add("@VERSION", attempts.version);
                parameters.Add("@LATITUDE", attempts.latitude);
                parameters.Add("@LONGITUDE", attempts.longitude);
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return parameters;
        }
        public DynamicParameters SetParametersInsertEmployee(UserRegistration model)
        {
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("@P_USER_NAME", model.userName);
                parameters.Add("@P_PASSWORD", model.password);
                parameters.Add("@P_EMAIL", model.email);
                parameters.Add("@P_MOBILE_NO",model.contact_no);
                parameters.Add("@P_BLOOD_GROUP",model.blood_group);
                parameters.Add("@P_NID_SNID", model.nid);
                parameters.Add("@P_PRESENT_ADDR", model.present_address);
                parameters.Add("@P_PERMANENT_ADDR", model.permanent_address);
                parameters.Add("@P_FATHERS_NAME", model.fathers_name);
                parameters.Add("@P_MOTHERS_NAME", model.mothers_name);
                parameters.Add("@G_CONTACT", model.g_contact_no);
                parameters.Add("@DEST_ID", model.designation_id);
                parameters.Add("@DESIGNATION_NAME", model.designation_name);

            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return parameters;
        }
        public DynamicParameters TokenValidate(string loginProvider, int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            try
            {
                parameters.Add("@P_SESSION_TOKEN", loginProvider);
                parameters.Add("@P_USER_ID", userId);
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return parameters;
        }
    }
}
