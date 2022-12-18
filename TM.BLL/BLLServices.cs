using Microsoft.Extensions.DependencyInjection;
using TM.BLL.BLLInterface;
using TM.BLL.Implementation;

namespace TM.BLL
{
    public static class BLLServices
    {
        public static IServiceCollection AddBll(this IServiceCollection service)
        {
            service.AddTransient<IBLLSecurity, BLLSecurity>();
            service.AddTransient<IBllTaskDetails, BLLTasksDetails>();
            service.AddTransient<ISessionSplit, BLLSessionSplit>();
            service.AddTransient<IBllTeam, BLLTeam>();
            return service;
        }
    }
}