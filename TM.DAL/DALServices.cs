using Microsoft.Extensions.DependencyInjection;
using TM.DAL.DALInterface;
using TM.DAL.Repository;

namespace TM.DAL
{
    public static class DALServices
    {
        public static IServiceCollection AddDAL(this IServiceCollection service)
        {
            service.AddTransient<ITaskDetails, TaskDetailsRepository>();
            service.AddTransient<ISecurityBase, SecurityBase>();
            return service;
        } 
    } 
}