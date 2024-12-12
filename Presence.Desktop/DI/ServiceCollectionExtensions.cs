using Data.Repository;
using Data;
using Domain.Service;
using Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;
using Presence.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presence.Desktop.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonService(this IServiceCollection collection)
        {
            collection.AddDbContext<RemoteDatabaseContext>()
                .AddSingleton<IGroupRepository, SQLGroupRepository>()
                .AddSingleton<IStudentsRepository, SQLStudentsRepository>()
                .AddTransient<IGroupUseCase, GroupService>()
                .AddTransient<IStudentsUseCase, StudentsService>()
                .AddTransient<MainWindowViewModel>()
                .AddTransient<GroupViewModel>();
        }
    }
}
