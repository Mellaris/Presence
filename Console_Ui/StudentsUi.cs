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
            Students students = new Students();
            Console.WriteLine("Введите фио студента");
            students.Fio = Console.ReadLine();
            Console.WriteLine("Введите id группы");
            students.IdGroup = new Groups { Id = Int32.Parse(Console.ReadLine()) };
            _studentsUseCase.AddStudents(new AddStudentsRequest { IdGroup = students.IdGroup, Name = students.Fio });

            //_studentsUseCase.AddStudents(IdG, new AddStudentsRequest { IdGroup = IdG, Name = studentName });
        }
    }
}
