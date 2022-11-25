using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DAL.DALInterface;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.DAL.Repository
{
    public class TaskDetailsRepository : ITaskDetails
    {
        public List<TaskResponse> GetTaskList(CommonRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
