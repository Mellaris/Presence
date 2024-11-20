using Console_Ui;
using Data;
using Data.Repository;
using Domain.Service;
using Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;


void printAllGroups(IGroupRepository groupRepository)
{
    foreach(var item in groupRepository.GetAllGroup())
    {
        Console.WriteLine($"{item.Id}  {item.Name}");
    }
}


IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection
    .AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IGroupRepository, SQLGroupRepository>()
    .AddSingleton<IGroupUseCase, GroupService>()
    .AddSingleton<GroupUi>();

var servicProvider = serviceCollection.BuildServiceProvider();
var groupUi = servicProvider.GetService<GroupUi>();

groupUi?.UpdateGroup();


