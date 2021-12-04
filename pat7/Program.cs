using System.Collections;

namespace pat7
{
    class Program
    {
        public class Student
        {
            public string Name;
            public string Surname;
            public string Middlename;
            public DateTime BDate;
            public override string ToString() => $"{Surname} {Name} {Middlename} {BDate.ToShortDateString()}";
        }
        public class StudentGroup
        {
            public string Name;
            public DateTime Graduation;
            public DateTime Admission;
            public int ExamsCount;
            public int CreditsCount;
            private List<Student> students = new List<Student>();

            public int CurrentYearOfStudy
            {
                get => DateTime.Now > Graduation || DateTime.Now < Admission ? 0 : new DateTime((DateTime.Now - Admission).Ticks).Year;
            }
            private int GetSemester(DateTime dateTime) => dateTime.Month >= 9 ? 1 : 2;
            public int CurrentSemester
            {
                get => DateTime.Now > Graduation || DateTime.Now < Admission ? 0 : (new DateTime((DateTime.Now - Admission).Ticks).Year - 1) * 2 + GetSemester(DateTime.Now);
            }
            public int StudentsCount
            {
                get => students.Count;
            }
            public override string ToString()
            {
                var fStudents = StudentsCount > 0 ? String.Concat("Студенты:\n\r\t", $"{String.Join("\n\r\t", students)}") : "";
                return
                    $"Группа: {Name}" +
                    $"\n\rДата поступления: {Admission.ToShortDateString()}" +
                    $"\n\rДата выпуска: {Graduation.ToShortDateString()}" +
                    $"\n\rТекущий курс: {CurrentYearOfStudy}" +
                    $"\n\rТекущий семестр: {CurrentSemester}" +
                    $"\n\rКоличество экзаменов: {ExamsCount}" +
                    $"\n\rКоличество зачетов: {CreditsCount}" +
                    $"\n\rКоличество студентов: {StudentsCount}" +
                    $"\n\r{fStudents}";
            }
            public void AddStudent(Student student) => students.Add(student is null ? new Student() : student);
            public bool DelStudent(string field) => String.IsNullOrEmpty(field) ? false : students.Remove(students.FirstOrDefault(s => s.ToString().Contains(field)));
        }
        public static StudentGroup CurrentStudentGroup
        {
            get
            {
                if (currentStudentGroup is null)
                    currentStudentGroup = new StudentGroup()
                    {
                        Name = "ЭМА-18",
                        CreditsCount = 60,
                        ExamsCount = 30,
                        Admission = Convert.ToDateTime("01.09.2018"),
                        Graduation = Convert.ToDateTime("30.06.2022")
                    };
                return currentStudentGroup;
            }
        }
        private static StudentGroup currentStudentGroup;
        static void Main(string[] args) => ConsoleReader();
        public static void ConsoleReader()
        {
            Console.WriteLine("Для появления справки нажмите - Enter...");
            while (true)
            {
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Введите название группы:");
                            CurrentStudentGroup.Name = Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Введите дату начала учебы группы (дд.мм.гггг):");
                            CurrentStudentGroup.Admission = Convert.ToDateTime(Console.ReadLine());
                            break;
                        case "3":
                            Console.WriteLine("Введите дату начала окончания группы (дд.мм.гггг):");
                            CurrentStudentGroup.Graduation = Convert.ToDateTime(Console.ReadLine());
                            break;
                        case "4":
                            Console.WriteLine("Введите количество экзаменов у группы:");
                            CurrentStudentGroup.ExamsCount = Convert.ToInt32(Console.ReadLine());
                            break;
                        case "5":
                            Console.WriteLine("Введите количество экзаменов у группы:");
                            CurrentStudentGroup.CreditsCount = Convert.ToInt32(Console.ReadLine());
                            break;
                        case "6":
                            Console.WriteLine("Введите фамилию студента:");
                            var surname = Console.ReadLine();
                            Console.WriteLine("Введите имя студента:");
                            var name = Console.ReadLine();
                            Console.WriteLine("Введите отчество студента:");
                            var middlename = Console.ReadLine();
                            Console.WriteLine("Введите датурождения студента (дд.мм.гггг):");
                            CurrentStudentGroup.AddStudent(new Student() 
                            { 
                                Surname = surname, 
                                Name = name, 
                                Middlename = middlename, 
                                BDate = Convert.ToDateTime(Console.ReadLine()) 
                            });
                            break;
                        case "7":
                            Console.WriteLine("Введите Фамилию/Имя/Отчество/Дату рождения студента:");
                            CurrentStudentGroup.DelStudent(Console.ReadLine());
                            break;
                        case "exit":
                            return;
                        default:
                            {
                                Console.WriteLine(
                                       $"Изменения группы студентов: \n\r" +
                                       $"\tИзменить название группы         1\n\r" +
                                       $"\tИзменить дату начала учебы       2\n\r" +
                                       $"\tИзменить дату окончания          3\n\r" +
                                       $"\tИзменить количество экзаменов    4\n\r" +
                                       $"\tИзменить количество зачетов      5\n\r" +
                                       $"\tДобавить студента                6\n\r" +
                                       $"\tУдалить студента                 7\n\r\n\r" +
                                       $"Выход                              exit\n\r");
                                break;
                            }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    var currentStudentGroupInfo = currentStudentGroup is null ? "Группа не создана" : currentStudentGroup.ToString();
                    Console.WriteLine($"Информация о группе студентов:" +
                        $"\n\r{currentStudentGroupInfo}");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}