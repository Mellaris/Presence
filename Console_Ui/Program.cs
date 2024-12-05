using Console_Ui;
using Data;
using Data.Repository;
using Domain.Service;
using Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;
using System;


void printAllGroups(IGroupRepository groupRepository)
{
    foreach(var item in groupRepository.GetAllGroup())
    {
        Console.WriteLine($"{item.Id}  {item.Name}");
    }
}



IServiceCollection serviceCollection = new ServiceCollection();
//serviceCollection
//    .AddDbContext<RemoteDatabaseContext>()
//    .AddSingleton<IGroupRepository, SQLGroupRepository>()
//    .AddSingleton<IGroupUseCase, GroupService>()
//    .AddSingleton<GroupUi>();

serviceCollection
    .AddDbContext<RemoteDatabaseContext>()
    .AddSingleton<IStudentsRepository, SQLStudentsRepository>()
    .AddSingleton<IStudentsUseCase, StudentsService>()
    .AddSingleton<StudentsUi>();


//serviceCollection
//    .AddDbContext<RemoteDatabaseContext>()
//    .AddSingleton<ISubjectRepository, SQLSubjectRepository>()
//    .AddSingleton<ISubjectUseCase, SubjectService>()
//    .AddSingleton<SubjectUi>();

var servicProvider = serviceCollection.BuildServiceProvider();
//var groupUi = servicProvider.GetService<GroupUi>();
var studentUi = servicProvider.GetService<StudentsUi>();
//var subjectsUi = servicProvider.GetService<SubjectUi>();
studentUi?.AddStudent();


