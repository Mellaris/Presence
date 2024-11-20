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
            //Console.WriteLine("Введите фио студента");
            //string studentName = Console.ReadLine();
            //Console.WriteLine("Введите id группы");
            //Groups IdG = Console.ReadLine();

            //_studentsUseCase.AddStudents(IdG, new AddStudentsRequest { IdGroup = IdG, Name = studentName });
        }
    }
}
