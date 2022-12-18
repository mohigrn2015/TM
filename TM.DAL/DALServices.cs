using Microsoft.Extensions.DependencyInjection;
using TM.DAL.DALInterface;
using TM.DAL.Repository;

namespace TM.DAL
{
    public static class DALServices
    {
        public static IServiceCollection AddDAL(this IServiceCollection service)
        {
            service.AddTransient<IDALTaskDetails, TaskDetailsRepository>();
            service.AddTransient<IDALSecurityBase, SecurityBase>();
            service.AddTransient<IDALTeamMange, TeamMangeRepository>();
            service.AddTransient<IDALRoleManage, RoleMangeRepository>();
            return service;
        } 
    } 
}