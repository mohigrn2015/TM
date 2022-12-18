using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.BLL.BLLCommon;
using TM.BLL.BLLInterface;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.Controllers
{
    [Route("api/team-manage")]
    [ApiController]
    public class TeamManageController : ControllerBase
    {
        private IBllTeam _bllTeam;
        private ISessionSplit _session;
        public TeamManageController(IBllTeam team, ISessionSplit sessionSplit)
        {
            _bllTeam = team;  
            _session = sessionSplit;
        }
        [HttpPost]
        [Route("add-team")]
        public async Task<IActionResult> AddTeam([FromBody] TeamRequestModel model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            CommonResponseModel responseModel = new CommonResponseModel();
            long insertedId = 0;
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                insertedId = _bllTeam.AddTeam(model);

                if(insertedId > 0)
                {
                    responseModel.result = true;
                    responseModel.message = MessageCollection.SuccessSave;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(responseModel);
        }
        [HttpPost]
        [Route("update-team")] 
        public async Task<IActionResult> UpdateTeam([FromBody] TeamRequestModel model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            CommonResponseModel responseModel = new CommonResponseModel();  
            long insertedId = 0;
            try
            { 
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                insertedId = _bllTeam.UpdateTeam(model);

                if(insertedId > 0)
                {
                    responseModel.result = true;
                    responseModel.message=MessageCollection.SuccessUpdate;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(insertedId);
        }
        [HttpPost]
        [Route("get-team-list")] 
        public async Task<IActionResult> GetTeam([FromBody] TeamRequestModel model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<TeamResponseModel> teamResponses = new List<TeamResponseModel>();
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }
                teamResponses = _bllTeam.GetAllTeams(model); 
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(teamResponses);
        }
        [HttpPost]
        [Route("delete-team")]
        public async Task<IActionResult> DeleteTeam([FromBody] TeamRequestModel model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            CommonResponseModel responseModel = new CommonResponseModel();
            long teamResponses = 0;
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                teamResponses = _bllTeam.DeleateTeam(model);

                if(teamResponses > 0)
                {
                    responseModel = new CommonResponseModel();
                    responseModel.result = true;
                    responseModel.message = MessageCollection.SuccessDelete;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(teamResponses);
        }
    }
}
