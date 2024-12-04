using Domain.Request;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Ui
{
    class SubjectUi
    {
        private readonly ISubjectUseCase _subjectService;
        public SubjectUi(ISubjectUseCase subjectService)
        {
            _subjectService = subjectService;
        }

        public void AddSubject()
        {
            Console.WriteLine("Введите название предмета: ");
            _subjectService
                .AddSubject(new AddSubjectRequest 
                { SubjectName = Console.ReadLine() });
        }

        public void RemoveSubject()
        {
            Console.WriteLine("Введите id предмета для удаления");
            _subjectService
                .RemoveSubject(new RemoveSubjectRequest 
                { SubjectId = Int32.Parse(Console.ReadLine()) });
        }

        public void UpdateSubject()
        {
            Console.WriteLine("Введите id предмета");
            int Id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое название предмета");
            _subjectService.UpdateSubject(Id, new UpdateSubjectRequest { NameSub = Console.ReadLine() });
        }
    }
}
