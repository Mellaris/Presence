using Data.DAO;
using Data.Repository;
using Domain.Request;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GroupSubsService : IGroupSubsUseCase
    {
        private readonly IGroupSubjectRepository _groupSubjectRepository;

        public GroupSubsService(IGroupSubjectRepository groupSubjectRepository)
        {
            _groupSubjectRepository = groupSubjectRepository;
        }
        public void AddGroupSubject(AddGroupSubjectsRequest addGroupSubjects)
        {
            foreach (var subject in addGroupSubjects.subjects)
            {
                _groupSubjectRepository.AddGroupSubject(new GroupsAndSubject { GroupId =  addGroupSubjects.GroupId, Semestr = Convert.ToString(subject.Semestr), SubjectId = subject.SubjectId });
            }
        }
    }
}
