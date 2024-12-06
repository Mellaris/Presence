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
            services
                .AddScoped<ISubjectRepository, SQLSubjectRepository>()
                .AddScoped<ISubjectUseCase, SubjectService>()
                .AddScoped<AdminController>();
            services
                .AddScoped<IStudentsRepository, SQLStudentsRepository>()
                .AddScoped<IStudentsUseCase, StudentsService>()
                .AddScoped<AdminController>();
            services
                .AddScoped<IGroupSubjectRepository, SQLGroupSubjectRepository>()
                .AddScoped<IGroupSubsUseCase, GroupSubsService>()
                .AddScoped<AdminController>();
        }
        
    }
}
