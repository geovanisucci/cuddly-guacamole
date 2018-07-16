using guacamole.Application.Application.Main;
using guacamole.Application.Interfaces.Main;
using guacamole.Domain.Iterfaces.IRepositories.Main;
using guacamole.Domain.Iterfaces.IServices.Main;
using guacamole.Domain.Services.Main;
using guacamole.Infra.Data.Contexts;
using guacamole.Infra.Data.Repositories.Main;
using Microsoft.Extensions.DependencyInjection;

namespace guacamole.Cross.IoC.InjectionDependency.Config
{
    public class IoC
    {
        
        public static void ConfigureDependencies(IServiceCollection services)
        {
            
            services.AddScoped<MainContext>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}