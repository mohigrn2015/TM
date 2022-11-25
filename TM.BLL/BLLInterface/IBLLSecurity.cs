using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.BLL.BLLInterface
{
    public interface IBLLSecurity
    {
        ValidateUser ValidateUsers(string user_name, string encPassword);
        long SaveLoginAttempts(UserLoginAttempts attempts);
        long Register(UserRegistration model);
    }
}
