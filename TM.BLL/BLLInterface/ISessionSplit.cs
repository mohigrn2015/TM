using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Response.Entity;

namespace TM.BLL.BLLInterface
{
    public interface ISessionSplit
    {
        SequrityValue ValidateSessionToken(string sessionToken);
        SequrityValue GetDataFromSecurityToken(string decryptedSessiontoken);
    }
}
