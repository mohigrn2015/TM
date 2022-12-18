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
    public class TaskDetailsRepository : IDALTaskDetails
    {
        LogsHandler _logsHandler = new LogsHandler();
        DynamicParams _dynamic = new DynamicParams();
        public long AddTask(TaskManageReq model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<TaskManageReq>("US_ADD_TASKINITATE", _dynamic.SetParametersInsertTaskInitiate(model), commandType: CommandType.StoredProcedure);

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

        public List<TasksResponses> GetTaskList(CommonRequestModel model)
        {
            _dynamic = new DynamicParams();
            List<TasksResponses> taskList = new List<TasksResponses>();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<TasksResponses>("UG_GET_TASKLIST", _dynamic.SetParametersGetTaskList(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        taskList = new List<TasksResponses>();
                        taskList = attemp.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return taskList;

        }

        public long UpdateInitialTask(int taskId)
        {
            long result = 0;
            _dynamic = new DynamicParams();
            List<TasksResponses> taskList = new List<TasksResponses>();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<TasksResponses>("US_UPD_TASKLIST", _dynamic.SetParametersUPDTaskList(taskId), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        taskList = new List<TasksResponses>();
                        result = Convert.ToInt32(attemp.FirstOrDefault().taskid);
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return result;
        }
    }
}
