using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUnLearningSys
{
    class MainClass
    {
        static void Main(string[] args)
        {
            List<Person> students = new List<Person>()
            {
                new OnlineStudent("Peter","Stoyanov",22,808011,4.22m,"C# Advanced"),
                new OnlineStudent("Ivan","Todorov",20,808021,3.82m,"C# Advanced"),
                new OnsiteStudent("Daniela","Petrova",21,818020,4.55m,"Programming Basic",10),
                new OnsiteStudent("Lidia","Popova",21,828031,5.00m,"Programming Basic",12),
                new DropoutStudent("Georgi","Georgiev",24,828311,2.70m,"Poor Results"),
                new DropoutStudent("Nikolay","Gerov",18,827211,2.30m,"Poor Results"),
                new GraduateStudent("Petia","Ivanova",24,826212,5.00m),
                new SeniorTrainer("Atanas","Petkov",26),
                new SeniorTrainer("Valentin","Dimitrov",28),
                new JuniorTrainer("Todor","Shopov",27)
            };          
            var currentStudents = students.OfType<CurrentStudent>().OrderBy(s => s.AverageGrade).ToList();
            foreach (var student in currentStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
