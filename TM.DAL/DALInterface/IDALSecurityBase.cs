using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.DAL.DALInterface
{
    public interface IDALSecurityBase
    {
        ValidateUser ValidateUser(string user_name, string encPassword);
        long SaveLoginInfo(UserLoginAttempts attempts);
        long SaveEmployee(UserRegistration model);
        int ValidateSessionToken(TokenValidationRequest model);
    }
}
