using Data.DAO;
using Data.Repository;
using Domain.Entity;
using Domain.Request;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class SubjectService : ISubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void AddSubject(AddSubjectRequest addSubjectRequest)
        {
            _subjectRepository
                .AddSubject(new Subjects
                {
                    Name = addSubjectRequest.SubjectName
                });
        }

        public IEnumerable<SubjectEntity> GetAllSubject()
        {
            throw new NotImplementedException();
        }

        public void RemoveSubject(RemoveSubjectRequest removeSubjectRequest)
        {
            _subjectRepository
                .RemoveSubject(removeSubjectRequest.SubjectId);
        }

        public void UpdateSubject(int Id, UpdateSubjectRequest updateSubjectRequest)
        {
            _subjectRepository
                .UpdateSubject(Id, new Subjects 
                { Name = updateSubjectRequest.NameSub });
        }
    }
}
