using Domain.Request;
using Domain.Service;
using Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Data.DAO;

namespace Console_Ui
{
    class StudentsUi
    {
        private readonly IStudentsUseCase _studentsUseCase;
        public StudentsUi(IStudentsUseCase studentsUseCase)
        {
            _studentsUseCase = studentsUseCase;
        }
        public void AddStudent()
        {
            Console.WriteLine("Введите фио студента");
            Students students = new Students();
            students.Fio = Console.ReadLine();
            Console.WriteLine("Введите id группы");
            students.IdGroup = new Groups { Id = Int32.Parse(Console.ReadLine()) };
            _studentsUseCase.AddStudents(new AddStudentsRequest { Name = students.Fio, GroupId = students.IdGroup });
        }
        public void RemoveStudent()
        {
            Console.WriteLine("Введите id студента");
            _studentsUseCase.RemoveStudents(new RemoveStudentsRequest { idS = Convert.ToInt32(Console.ReadLine()) });
        }
    }
}
