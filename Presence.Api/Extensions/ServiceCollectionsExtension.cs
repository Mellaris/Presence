using Data;
using Data.Repository;
using Domain.Service;
using Presence.Api.Controllers;
using Domain.UseCase;
using System.Runtime.CompilerServices;

namespace Presence.Api.Extensions
{
    public static class ServiceCollectionsExtension
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services
                .AddDbContext<RemoteDatabaseContext>()
                .AddScoped<IGroupRepository, SQLGroupRepository>()
                .AddScoped<IGroupUseCase, GroupService>()
                .AddScoped<GroupController>();
        }
    }
}
