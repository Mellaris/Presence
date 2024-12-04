using Domain.Entity;
using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface ISubjectUseCase
    {
        public void AddSubject(AddSubjectRequest addSubjectRequest);

        public void RemoveSubject(RemoveSubjectRequest removeSubjectRequest);

        public void UpdateSubject(int Id, UpdateSubjectRequest updateSubjectRequest);
        public IEnumerable<SubjectEntity> GetAllSubject();
    }
}
