using Microsoft.Extensions.DependencyInjection;
using CRM.Services.UsersService;

namespace CRM.Services
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
