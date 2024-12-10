using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Domain.UseCase;
using Domain.Service;
using Data;
using Attendance.Desktop.ViewModels;

namespace Attendance.Desktop.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonService(this IServiceCollection collection)
        {
            collection
                .AddDbContext<RemoteDatabaseContext>()
                .AddSingleton<IGroupRepository, SQLGroupRepository>()
                .AddTransient<IGroupUseCase, GroupService>()
                .AddTransient<MainWindowViewModel>();
        }
    }
}
