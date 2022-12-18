using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TM.BLL.BLLCommon;
using TM.BLL.BLLInterface;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.Controllers
{
    [Route("api/user-mange")]
    [ApiController]
    public class UserMangeController : ControllerBase
    {
        private IBLLRoleManage _bLLRoleManage;
        private ISessionSplit _session;
        public UserMangeController(IBLLRoleManage roleManage, ISessionSplit session)
        {
            _bLLRoleManage = roleManage;
            _session = session; 
        }

        [HttpPost]
        [Route("feature-list")]
        public async Task<IActionResult> GetAllFeature([FromBody] RoleManageRequest model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<RoleMangeResponseModel> roleFeatureResponse = new List<RoleMangeResponseModel>();
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                roleFeatureResponse = _bLLRoleManage.GetFeatureList(model);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(roleFeatureResponse);
        }

        [HttpPost]
        [Route("active-feature")]
        public async Task<IActionResult> GetActiveFeature([FromBody] RoleManageRequest model)
        { 
            SequrityValue sequrityValue = new SequrityValue();
            List<AssignedRoleResponseModel> roleFeatureResponse = new List<AssignedRoleResponseModel>();
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                roleFeatureResponse = _bLLRoleManage.GetActiveFeatures(model);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(roleFeatureResponse);
        }
        [HttpPost] 
        [Route("manage-role")]
        public async Task<IActionResult> ManageUserRole([FromBody] RoleManageRequest model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            long roleManage = 0;
            CommonResponseModel responseModel = new CommonResponseModel();
            try
            { 
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                { 
                    throw new Exception("Invalid session token!");
                }

                roleManage = _bLLRoleManage.RoleManage(model);

                if(roleManage > 0)
                {
                    responseModel = new CommonResponseModel();
                    responseModel.result = true;
                    responseModel.message = MessageCollection.SuccessUpdate;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(responseModel);
        }
        [HttpPost]
        [Route("assign-role")] 
        public async Task<IActionResult> AssignRoleToUser([FromBody] RoleManageRequest model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            long roleManage = 0;
            CommonResponseModel responseModel = new CommonResponseModel();
            try
            {
                sequrityValue = _session.ValidateSessionToken(model.Session_Token);

                if (sequrityValue.isSessionValid != 1)
                {
                    throw new Exception("Invalid session token!");
                }

                roleManage = _bLLRoleManage.RoleAssignToUser(model);

                if (roleManage > 0)
                {
                    responseModel = new CommonResponseModel();
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
    }
}
