using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAO;
using Data.Repository;
using Domain.Request;
using Domain.UseCase;

namespace Domain.Service
{
    public class StudentsService : IStudentsUseCase
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        public void AddStudents(AddStudentsRequest addStudentsRequest, Groups Id)
        {
            _studentsRepository.AddStudents(new Students { Fio = addStudentsRequest.Name, IdGroup = Id});
        }
    }
}
