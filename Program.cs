using System;
using System.Diagnostics; 
using System.Linq;
using FullTeamWork1;

namespace FullTeamWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Вадим", "Крутой", new DateTime(2000, 1, 1));
            Student student = new Student(person, Education.Bachelor, 101);
            Console.WriteLine(student.ToShortString());

            Console.WriteLine($"Специалитет: {student[Education.Specialist]}");
            Console.WriteLine($"Бакалавриат: {student[Education.Bachelor]}");
            Console.WriteLine($"Второе высшее: {student[Education.SecondEducation]}");

            student.Person = new Person("Дима", "Невадов", new DateTime(1999, 5, 15));
            student.Education = Education.SecondEducation;
            student.GroupNumber = 202;
            Console.WriteLine(student.ToString());

            student.AddExams(
                new Exam("Математика", 85, new DateTime(2024, 11, 15)),
                new Exam("Программирование", 90, new DateTime(2024, 11, 16))
            );
            Console.WriteLine(student.ToString());

            CompareArrayPerformance();
        }

        static void CompareArrayPerformance()
        {
            const int size = 1000000;
            Exam[] oneDimensional = new Exam[size];
            Exam[,] twoDimensional = new Exam[1000, 1000];
            Exam[][] jaggedArray = new Exam[1000][];
            for (int i = 0; i < 1000; i++)
                jaggedArray[i] = new Exam[1000];

            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch(); 

            stopwatch.Start();
            for (int i = 0; i < size; i++) oneDimensional[i] = new Exam("Предмет", random.Next(50, 100), DateTime.Now);
            stopwatch.Stop();
            Console.WriteLine($"\n" +
                $"[---------------------------------------------------------------]\n" +
                $"Время заполнения одномерного массива: {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    twoDimensional[i, j] = new Exam("Предмет", random.Next(50, 100), DateTime.Now);
            stopwatch.Stop();
            Console.WriteLine($"Время заполнения двумерного массива: {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    jaggedArray[i][j] = new Exam("Предмет", random.Next(50, 100), DateTime.Now);
            stopwatch.Stop();
            Console.WriteLine($"Время заполнения ступенчатого массива: {stopwatch.ElapsedMilliseconds} мс\n" +
                $"[---------------------------------------------------------------]");

        }
    }
}