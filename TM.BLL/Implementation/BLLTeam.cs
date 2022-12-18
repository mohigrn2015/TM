using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.BLL.BLLInterface;
using TM.DAL.DALInterface;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.BLL.Implementation
{
    public class BLLTeam : IBllTeam
    {
        private IDALTeamMange _teamMange; 
        public BLLTeam(IDALTeamMange team)
        {
            _teamMange = team;  
        }
        public long AddTeam(TeamRequestModel model)
        {
            long inserted = 0;
            try
            {
                inserted = _teamMange.AddTeam(model);
            }
            catch (Exception)
            {
                throw;
            }
            return inserted;    
        }

        public long DeleateTeam(TeamRequestModel model)
        {
            long deleted = 0;   
            try
            {
                deleted = _teamMange.DeleateTeam(model);    
            }
            catch (Exception)
            {
                throw;
            }
            return deleted;
        }

        public List<TeamResponseModel> GetAllTeams(CommonRequestModel model)
        {
            List<TeamResponseModel> teams = new List<TeamResponseModel>();  
            try
            {
                teams = _teamMange.GetAllTeams(model);  
            }
            catch (Exception)
            {
                throw;
            }
            return teams;
        }

        public long UpdateTeam(TeamRequestModel model)
        {
            long updated = 0;   
            try
            {
                updated = _teamMange.UpdateTeam(model); 
            }
            catch (Exception)
            {
                throw;
            }
            return updated;
        }
    }
}
