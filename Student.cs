using System;
using FullTeamWork1;

namespace FullTeamWork1
{
    public class Student
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private List<Exam> exams = new List<Exam>();
        public Person Person { get => person; set => person = value ?? throw new ArgumentNullException(nameof(value)); }
        public Education Education { get => education; set => education = value; }
        public int GroupNumber { get => groupNumber; set => groupNumber = value < 0 ? throw new ArgumentException("Номер группы должен быть положительным") : value; }
        public Exam[] Exams { get => exams.ToArray(); set => exams = value != null ? new List<Exam>(value) : new List<Exam>(); } 

        public bool this[Education educationIndex] => education == educationIndex;

        public double AverageGrade
        {
            get
            {
                if (exams == null || exams.Count == 0) return 0; 
                double sum = 0;
                foreach (var exam in exams)
                {
                    sum += exam.Grade;
                }
                return sum / exams.Count;
            }
        }


        public Student(Person person, Education education, int groupNumber)
        {
            Person = person;
            Education = education;
            GroupNumber = groupNumber;
        }

        public Student() : this(new Person(), Education.Bachelor, 0) { }

        public void AddExams(params Exam[] newExams)
        {
            if (newExams != null) exams.AddRange(newExams);
        }

        public override string ToString()
        {
            string examList = exams.Count == 0 ? "Экзамены не сданы." : string.Join("\n", exams);
            return $"ФИО: {Person}, Образование: {Education}, Группа: {GroupNumber}\nЭкзамены:\n{examList}";
        }
        public virtual string ToShortString()
        {
            return $"ФИО: {Person}, Образование: {Education}, Группа: {GroupNumber}, Средний балл: {AverageGrade:F2}";
        }
    }
}

