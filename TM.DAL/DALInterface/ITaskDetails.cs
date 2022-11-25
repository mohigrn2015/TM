using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.DAL.DALInterface
{
    internal interface ITaskDetails
    {
        List<TaskResponse> GetTaskList(CommonRequestModel model);
    }
}
