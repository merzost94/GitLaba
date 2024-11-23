using System;

namespace FullTeamWork1
{
    public class Exam
    {
        public string Subject { get; set; } = "Неизвестно";
        public int Grade { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.MinValue;

        public Exam(string subject, int grade, DateTime date)
        {
            Subject = subject;
            Grade = grade;
            Date = date;
        }
        public Exam() { }

        public override string ToString()
        {
            return $"Предмет: {Subject}, Оценка: {Grade}, Дата: {Date.ToShortDateString()}";
        }
    }
}
