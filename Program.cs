using System;
using System.Runtime.CompilerServices;
using Final_Task_OOP;

class Program
{
    static void Main()
    {
        Console.WriteLine("Exersice One : ************************************************************* ");
        Console.WriteLine();
        MyGenericList<int> EngineersID = new MyGenericList<int>();
        EngineersID.AddElement(1);
        EngineersID.AddElement(2);
        EngineersID.AddElement(3);

        Console.WriteLine("The EngineersID generic list contains:");
        foreach (var id in EngineersID.GetElements())
        {
            Console.WriteLine(id);
        }
        EngineersID.DisplayFirstElement();




        MyGenericList<string> EngineersNames = new MyGenericList<string>();
        EngineersNames.AddElement("Eng: Dana Kanaan");
        EngineersNames.AddElement("Eng: Esraa Othman");
        EngineersNames.AddElement("Eng: Bayan");

        Console.WriteLine("\nThe EngineersNames generic list contains:");
        foreach (var name in EngineersNames.GetElements())
        {
            Console.WriteLine(name);
        }
        EngineersNames.DisplayFirstElement();


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        //--------- Exersice Two ---------------------
        Console.WriteLine("Exersice Two: ************************************************************* ");
        Console.WriteLine();


        string docPathOne = @"C:\Users\HP\Desktop\doc1.txt";
        string docPathTwo = @"C:\Users\HP\Desktop\doc2.txt";

        string DocOneReadedInfo = File.ReadAllText(docPathOne);

        string currentContentDoc2 = File.ReadAllText(docPathTwo);
        int oldWordCount = CountWords(currentContentDoc2);

        using (StreamWriter w = File.AppendText(docPathTwo))
        {
            w.WriteLine(DocOneReadedInfo);
        }

        string modifiContentDoc2 = File.ReadAllText(docPathTwo);
        int newWordCount = CountWords(DocOneReadedInfo);
        int totalWordCount = CountWords(modifiContentDoc2);

        Console.WriteLine("Old number of words in Doc2: " + oldWordCount);
        Console.WriteLine("Number of new words added from Doc1: " + newWordCount);
        Console.WriteLine("Total number of words in Doc2: " + totalWordCount);


        static int CountWords(string text)
        {
            int countAll = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                               .SelectMany(line => line.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                               .Count();
            return countAll;
        }




        //****************************
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("--------------------------------");




        //--------- Exersice Three ---------------------
        Console.WriteLine("Exersice Three : *************************************************************");
        Console.WriteLine();

        City city1 = new City("Amman", "Region");
        City city2 = new City("Irbid", "Region");

        School Sch1 = new School("Girls School", 1000);
        School Sch2 = new School("Boys School", 700);
        School Sch3 = new School("Kides School", 700);
        School Sch4 = new School("Gardens School", 700);


        Teacher T1 = new Teacher("Ahmed", 1);
        Teacher T2 = new Teacher("Sara", 2);
        Teacher T3 = new Teacher("Nedaa", 3);
        Teacher T4 = new Teacher("Mohammade", 4);
        Teacher T5 = new Teacher("Mazen", 5);
        Teacher T6 = new Teacher("Malak", 6);
        Teacher T7 = new Teacher("Moayed", 7);
        Teacher T8 = new Teacher("Momen", 8);

        Sch1.Teachers.Add(T1);
        Sch1.Teachers.Add(T2);
        Sch1.Teachers.Add(T3);
        Sch2.Teachers.Add(T4);
        Sch2.Teachers.Add(T5);
        Sch3.Teachers.Add(T6);
        Sch4.Teachers.Add(T7);
        Sch1.Teachers.Add(T8);



        city1.Schools.Add(Sch1);
        city1.Schools.Add(Sch2);
        city1.Schools.Add(Sch3);
        city2.Schools.Add(Sch4);




        DisplayCitySchoolsAndTeachers(city1);
        DisplayCitySchoolsAndTeachers(city2);

        DisplaySchoolWithMostTeachers(city1, city2);




        static void DisplayCitySchoolsAndTeachers(City city)
        {
            var query =
                from school in city.Schools
                select new
                {
                    SchoolName = school.School_Name,
                    CityName = city.City_Name,
                    Teachers = from teacher in school.Teachers
                               select new
                               {
                                   teacher.Teacher_Name,
                                   teacher.Teacher_Id
                               }
                };

            if (query.Any())
            {
                Console.WriteLine("City’s schools are:");
                foreach (var school in query)
                {
                    Console.WriteLine($" >> {school.SchoolName} in ==> {school.CityName}");
                    Console.WriteLine("Teachers:");
                    foreach (var teacher in school.Teachers)
                    {
                        Console.WriteLine($"- {teacher.Teacher_Name} (ID: {teacher.Teacher_Id})");
                    }
                    Console.WriteLine("-------------------------------");
                }
            }
        }

        static void DisplaySchoolWithMostTeachers(City city1, City city2)
        {
            var query =
                from school in city1.Schools.Concat(city2.Schools)
                orderby school.Teachers.Count descending
                select school;

            var schoolWithMostTeachers = query.FirstOrDefault();

            if (schoolWithMostTeachers != null)
            {
                Console.WriteLine($"\nSchool with the highest number of teachers: {schoolWithMostTeachers.School_Name}");

                var city = city1.Schools.Contains(schoolWithMostTeachers) ? city1 : city2;

                Console.WriteLine($"Location: {schoolWithMostTeachers.School_Name} in {city.City_Name}");

                Console.WriteLine($"Number of teachers: {schoolWithMostTeachers.Teachers.Count}");

                Console.WriteLine("Teachers:");
                foreach (var teacher in schoolWithMostTeachers.Teachers)
                {
                    Console.WriteLine($"- {teacher.Teacher_Name} (ID: {teacher.Teacher_Id})");
                }
            }
        }







        Console.WriteLine();
        Console.WriteLine("**********THE END THANK YOU****************");

        Console.ReadKey();


    }
}




