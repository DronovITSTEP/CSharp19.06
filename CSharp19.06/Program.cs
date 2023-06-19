using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp19._06
{
    public delegate T CalculateDelegate<T>(T x, T y);

    // delegate Action<T> -- void (T t1, T t2, .... до 16 параметров)
    // delegate Func<T> -- T (T t1, T t2, .... до 16 параметров)
    // delegate Predicate<T> -- bool (T t1)
    // delegate Comparison<T> -- int (T t1, T t2)

    //public event CalculateDelegate CalculateEvent;


    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: " +
                $"{BirthDate.ToShortDateString()}";
        }
        public void Exam(string task)
        {
            Console.WriteLine(FirstName + ' ' + task);
        }
    }
    class Teacher
    {
        public event ExamDelegate examEvent;

        public void Exam(string t)
        {
            if (examEvent != null)
            {
                examEvent(t);
            }
        }
    }

    internal class Program
    {
        static void FullName (Student student)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        static string FullName1(Student student)
        {
            return $"{student.FirstName} {student.LastName}";
        }
        static bool OnlySpring(Student student)
        {
            return student.BirthDate.Month >= 3 &&
                student.BirthDate.Month <= 5;
        }
        static int SortBirthDate(Student student1, Student student2)
        {
            return student1.BirthDate.CompareTo(student2.BirthDate);
        }
        static void Main(string[] args)
        {
            /*Calculator calculator = new Calculator();
            string str = Console.ReadLine();
            char sign = ' ';
            foreach (char c in str)
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    sign = c;
                    break;
                }
            }

            string[] numbers = str.Split(sign);
            CalculateDelegate<double> calc = null;

             switch (sign)
             {
                 case '+':
                     calc = new CalculateDelegate(calculator.Add); break;
                 case '-':
                     calc = new CalculateDelegate(calculator.Sub); break;
                 case '*':
                     calc = calculator.Mult; break;
                 case '/':
                     calc = calculator.Div; break;
             }
            calc = calculator.Add;
            calc += calculator.Sub;
            calc += calculator.Mult;

            foreach (CalculateDelegate<double> item in calc.GetInvocationList())
            {
                Console.WriteLine(item(double.Parse(numbers[0]),
                    double.Parse(numbers[1])));
            }

            calc -= calculator.Sub;
            Console.WriteLine();
            foreach (CalculateDelegate<double> item in calc.GetInvocationList())
            {
                Console.WriteLine(item(double.Parse(numbers[0]),
                    double.Parse(numbers[1])));
            }
            */

            List<Student> students = new List<Student>
            {
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    BirthDate = new DateTime(1998, 9, 15)
                },
                new Student
                {
                    FirstName = "Petr",
                    LastName = "Petrov",
                    BirthDate = new DateTime(2002, 2, 20)
                },
                new Student
                {
                    FirstName = "Lena",
                    LastName = "Lenova",
                    BirthDate = new DateTime(1992, 5, 3)
                }
            };

            //students.ForEach(FullName); -> Action<>

            //IEnumerable<string> stud = students.Select(FullName1); -> Func<>
            /*foreach (string s in stud)
            {
                Console.WriteLine(s);
            }*/

            //List<Student> stud = students.FindAll(OnlySpring); -> Predicate<>
            /*foreach(Student student in stud)
            {
                Console.WriteLine (student.FirstName);
            }*/

            //students.Sort(SortBirthDate); -> Comparison<>
            /*foreach (Student student in students)
            {
                Console.WriteLine(student);
            }*/

            Teacher teacher = new Teacher();
            foreach(Student student in students)
            {
                teacher.examEvent += student.Exam;
            }
            teacher.Exam("задание");

            Console.ReadKey();
        }
    }
}
