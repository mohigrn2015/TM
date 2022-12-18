using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TM.BLL.BLLCommon;
using TM.BLL.BLLInterface;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.Controllers
{
    [Route("api/task-manage")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private IBllTaskDetails _bllTaskDetails;
        private ISessionSplit _session;
        public TaskManagementController(IBllTaskDetails bllTaskDetails, ISessionSplit session)
        {
            _bllTaskDetails = bllTaskDetails; 
            _session = session; 
        }
        [HttpPost]
        [Route("add-initial-task")]
        public async Task<IActionResult> AddInitialTask([FromBody] TaskManageReq model)
        {
            TaskManageReq initialTask = new TaskManageReq();
            SequrityValue sequrityValue = new SequrityValue();
            CommonResponseModel responseModel = new CommonResponseModel();
            long value = 0;
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                value = _bllTaskDetails.AddTask(model);

                if(value > 0)
                {
                    responseModel.result = true;
                    responseModel.message = MessageCollection.SuccessSave;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(initialTask);
        }

        [HttpPost]
        [Route("show-initial-task")]
        public async Task<IActionResult> GetTaskWithActive([FromBody] CommonRequestModel model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<TasksResponses> responses = new List<TasksResponses>();    
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }
                model.RightId = sequrityValue.rightId;
                model.TeamId = sequrityValue.teamId;
                model.userId = sequrityValue.userId; 
                
                responses = _bllTaskDetails.GetTaskList(model);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(responses);
        }

        [HttpPost]
        [Route("update-initial-task")] 
        public async Task<IActionResult> UpdateInitialTask([FromBody] TaskManageReq model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            CommonResponseModel responseModel = new CommonResponseModel();    
            long value = 0;
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }
                model.RightId = sequrityValue.rightId;
                model.TeamId = sequrityValue.teamId;
                model.userId = sequrityValue.userId;

                value = _bllTaskDetails.UpdateInitialTask(model.taskid);

                if(value > 0)
                {
                    responseModel.result = true;
                    responseModel.message = MessageCollection.SuccessUpdate;
                }
            }
            catch (Exception ex)
            {
                throw;
            } 
            return Ok(responseModel);
        }
    }
}
