using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.BLL.BLLInterface;
using TM.DAL.Repository;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;
using TM.DAL.DALInterface;

namespace TM.BLL.Implementation
{
    public class BLLSecurity : IBLLSecurity
    {
        private ISecurityBase _security;
        public BLLSecurity(ISecurityBase security)
        {
            _security = security;
        }
        public long Register(UserRegistration model)
        {
            long insertedId = 0;
            insertedId = _security.SaveEmployee(model);
            return insertedId;
        }

        public long SaveLoginAttempts(UserLoginAttempts attempts)
        {
            long insertedId = 0;
            insertedId = _security.SaveLoginInfo(attempts);
            return insertedId;
        }

        public ValidateUser ValidateUsers(string user_name, string encPassword)
        {
            ValidateUser users = new ValidateUser();
            users = _security.ValidateUser(user_name, encPassword);
            return users;
        }
    }
}
