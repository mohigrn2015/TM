using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.BLL.BLLInterface
{
    public interface IBllTaskDetails
    {
        List<TasksResponses> GetTaskList(CommonRequestModel model);
        long AddTask(TaskManageReq model);
        long UpdateInitialTask(int taskId);

    }
}
