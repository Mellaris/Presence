using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IGroupSubsUseCase
    {
        public void AddGroupSubject(AddGroupSubjectsRequest addGroupSubjects);

    }
}
