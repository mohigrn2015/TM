using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.BLL.BLLCommon;
using TM.BLL.BLLInterface;
using TM.BLL.BLLUtility;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.Controllers
{
    [Route("api/Security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private IBLLSecurity _security;
        public SecurityController(IBLLSecurity bLLSecurity)
        {
            _security = bLLSecurity;
        }
        [HttpPost]
        [Route("LoginV1")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                UserLoginAttempts attempts = new UserLoginAttempts();
                string passWord = AESCriptography.Encrypt(login.password);
                string loginProvider = Guid.NewGuid().ToString();

                ValidateUser userModel = _security.ValidateUsers(login.user_name, passWord);

                if (userModel.is_success == 0)
                {
                    return Ok(new LoginResponseModel()
                    {
                        is_Authenticated = false,
                        auth_message = MessageCollection.InvalidUser,
                        hasUpdate = false,
                        session_token = "",
                        right_id = 0,
                        accessed_role = ""
                    });
                }

                attempts = new UserLoginAttempts()
                {
                    userId = userModel.userId,
                    loginProvider = loginProvider,
                    deviceId = login.device_id,
                    ip_address = "",
                    latitude = login.latitude,
                    longitude = login.longitude
                };

                Thread saveThread = new Thread(() => _security.SaveLoginAttempts(attempts));
                saveThread.Start();
                string accessToken = AESCriptography.Encrypt(String.Format(StringFormatCollection.AccessTokenFormat, loginProvider, userModel.userId, userModel.user_name, userModel.rightid, userModel.right_name, userModel.roleid, userModel.role_name, Guid.NewGuid()));
                //HttpContext.Session.SetString("sessionToken", accessToken);
                //HttpContext.Session.SetString("right", userModel.right_id.ToString());
                return Ok(new LoginResponseModel()
                {
                    is_Authenticated = true,
                    auth_message = MessageCollection.ValidUser,
                    hasUpdate = false,
                    session_token = accessToken,
                    right_id = userModel.rightid,
                    accessed_role = userModel.role_name,
                    userId = userModel.userId
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegistration registration)
        {
            CommonResponseModel commonResponseModel = new CommonResponseModel();
            try
            {
                string encPassword = AESCriptography.Encrypt(registration.password);
                registration.password = encPassword;
                long saveUser = _security.Register(registration);
                if (saveUser > 0)
                {
                    commonResponseModel.result = true;
                    commonResponseModel.message = "Successfuly registared";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(registration);    
        }

    }

}
