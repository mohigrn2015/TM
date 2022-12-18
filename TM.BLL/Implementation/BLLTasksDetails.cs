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
    internal class BLLTasksDetails : IBllTaskDetails
    {
        private readonly IDALTaskDetails _taskDetails;
        public BLLTasksDetails(IDALTaskDetails taskDetails)
        {
            _taskDetails = taskDetails;
        }
        public long AddTask(TaskManageReq model)
        {
            long insertedRow = 0;
            try
            {
                insertedRow = _taskDetails.AddTask(model);
            }
            catch (Exception ex)
            {
                throw;
            }
            return insertedRow;
        }

        public List<TasksResponses> GetTaskList(CommonRequestModel model)
        {
            List<TasksResponses> tasksList = new List<TasksResponses>();    
            try
            {
                tasksList = _taskDetails.GetTaskList(model);
            }
            catch (Exception ex)
            {

                throw;
            }
            return tasksList;
        }

        public long UpdateInitialTask(int taskId)
        {
            long result = 0;    
            try
            {
                result = _taskDetails.UpdateInitialTask(taskId);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
