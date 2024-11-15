using Console_Ui;
using Data;
using Data.Repository;
using Domain.Service;


void printAllGroups(IGroupRepository groupRepository)
{
    foreach(var item in groupRepository.GetAllGroup())
    {
        Console.WriteLine($"{item.Id}  {item.Name}");
    }
}


RemoteDatabaseContext remoteDatabaseContext = new RemoteDatabaseContext();
SQLGroupRepository groupRepository = new SQLGroupRepository(remoteDatabaseContext);
GroupService groupService = new GroupService(groupRepository);
GroupUi group = new GroupUi(groupService);

group.AddGroup();

printAllGroups(groupRepository);


