using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DAL.DALInterface;
using TM.DAL.DALUtility;
using TM.DAL.Parameters;
using TM.Entity;
using TM.Entity.Request.Entity;
using TM.Entity.Response.Entity;

namespace TM.DAL.Repository
{
    internal class TeamMangeRepository : IDALTeamMange
    {
        LogsHandler _logsHandler = new LogsHandler();
        DynamicParams _dynamic = new DynamicParams();

        public long AddTeam(TeamRequestModel model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<long>("US_ADD_TEAM", _dynamic.SetParametersInsertTeam(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp);
                    }
                }
            } 
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;

        }

        public long DeleateTeam(TeamRequestModel model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<long>("US_DELETE_TEAM", _dynamic.SetParametersDeleteTeam(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp);
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }

        public List<TeamResponseModel> GetAllTeams(CommonRequestModel model)
        {
            List<TeamResponseModel> responseModels = new List<TeamResponseModel>();
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<TeamResponseModel>("UG_GET_TEAM", _dynamic.SetParametersGetTeam(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        responseModels = attemp.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return responseModels;
        }

        public long UpdateTeam(TeamRequestModel model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(DataContext.ConnectionStrings))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<long>("US_UPD_TEAM", _dynamic.SetParametersUpdateTeam(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp);
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }
    }
}
