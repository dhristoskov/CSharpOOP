using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            List<Project> projects_list1 = new List<Project>();
            List<Project> projects_list2 = new List<Project>();
            List<Sale> sales_list1 = new List<Sale>();
            List<Sale> sales_list2 = new List<Sale>();
            List<Manager> managers = new List<Manager>();
            try
            {
                Project csharp = new Project("C# project", new DateTime(2015, 02, 01), "Game project", States.Open);
                Project java = new Project("Java project", new DateTime(2015, 05, 06), "N/A", States.Closed);
                Project php = new Project("PHP project", new DateTime(2015, 06, 01), "N/A", States.Open);
                Project oop = new Project("C# OOP project", new DateTime(2014, 12, 10), "N/A", States.Closed);
                Project javaScript = new Project("JavaScript project", new DateTime(2014, 02, 11), "N/A", States.Closed);
                projects_list1.Add(csharp);
                projects_list1.Add(java);
                projects_list2.Add(php);
                projects_list2.Add(oop);
                projects_list1.Add(javaScript);

                Sale hardDrive = new Sale("Hitachi", new DateTime(2015, 02, 01), 125.00m);
                Sale processor = new Sale("Intel i7", new DateTime(2014, 12, 01), 755.00m);
                Sale ramMemory = new Sale("Corsair", new DateTime(2015, 05, 07), 245.00m);
                Sale graphicsCard = new Sale("nVidia", new DateTime(2015, 06, 03), 1245.00m);
                Sale keyboard = new Sale("Razer", new DateTime(2015, 04, 10), 198.99m);
                Sale monitor = new Sale("Samsung", new DateTime(2015, 03, 17), 745.70m);
                sales_list1.Add(hardDrive);
                sales_list1.Add(processor);
                sales_list1.Add(ramMemory);
                sales_list2.Add(graphicsCard);
                sales_list2.Add(keyboard);
                sales_list2.Add(monitor);

                Manager marketingManager = new Manager("Todor", "Karamfilov", 858596, 1250.00m, Departments.Sales, new List<Employee>()
                { 
                    new SalesEmployee("Petia","Todorova",864563,850.00m,Departments.Sales,sales_list1),
                    new SalesEmployee("Dimitar","Dimitrov",785645,850.00m,Departments.Sales,sales_list2)
                });
                Manager programManager = new Manager("Kiril", "Kirov", 795645, 1450.50m, Departments.Marketing, new List<Employee>() 
                {
                    new Developer("Maria","Simeonova",894556,1455.55m,Departments.Marketing,projects_list1),
                    new Developer("Stefan","Gugov",895678,1400.99m,Departments.Marketing,projects_list2)
                });
                managers.Add(marketingManager);
                managers.Add(programManager);
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Empry list or empty First or Last Name");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalide salary or price");
            }
            managers.ForEach(a => Console.WriteLine(a));
        }
    }
}
