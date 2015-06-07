using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    class MainClass
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();
            try
            {
                students = new List<Student>()
                { 
                    new Student("Peter","Dimitrov","555444"),
                    new Student("Ivan","Stefanov","555123"),
                    new Student("Daniela","Ivanova","225444"),
                    new Student("Kaloian","Shopov","552324"),
                    new Student("Stefan","Petrov","511544"),
                    new Student("Kiril","Mitrov","212122"),
                    new Student("Valeria","Spasova","454545")
                };
                workers = new List<Worker>()
                {
                    new Worker("Todor","Pavlov",155.0m,8.0m),
                    new Worker("Petia","Gerova",135.0m,8.0m),
                    new Worker("Nadejda","Tomova",175.0m,9.0m),
                    new Worker("Nikolai","Atanasov",115.0m,5.0m),
                    new Worker("Silvia","Nikolava",215.0m,9.0m),
                    new Worker("Maria","Dimitrova",95.0m,4.0m),
                    new Worker("Veselin","Minkov",235.0m,10.0m),
                };
            }
            catch(FormatException)
            {
                Console.WriteLine("Incorrect Faculty Number");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Empty Name or Faculty Number");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Incorrect salary ot work hours");
            }

            Console.WriteLine("Sorted students:");
            Console.WriteLine();
            foreach (var student in students.OrderBy(x => x.FacultyNum))
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Console.WriteLine("Sorted workers:");
            Console.WriteLine();
            foreach (var worker in workers.OrderByDescending(x => x.MoneyPerHour))
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine("Press any key for next step in problem");
            Console.ReadKey();
            Console.Clear();
            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            foreach (var person in humans.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName))
            {
                Console.WriteLine(person);
            }
        }
    }
}
