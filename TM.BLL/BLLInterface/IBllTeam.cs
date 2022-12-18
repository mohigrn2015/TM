using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.BLL.BLLInterface
{
    public interface IBllTeam
    {
        long AddTeam(TeamRequestModel model);
        long UpdateTeam(TeamRequestModel model);
        List<TeamResponseModel> GetAllTeams(CommonRequestModel model);
        long DeleateTeam(TeamRequestModel model);
    }
}
