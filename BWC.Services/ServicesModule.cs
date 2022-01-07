using Microsoft.Extensions.DependencyInjection;
using BWC.Services.UsersService;

namespace BWC.Services
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
