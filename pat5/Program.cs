using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace pat5
{
    internal class Program
    {
        public interface IBuilder
        {
            public void SetSurName(string SurName);
            public void SetName(string Name);
            public void SetMiddleName(string MiddleName);
            public void SetBirthDate(DateTime BirthDate);
            public void SetGender(Gender gender);
            public void SetEducationForm(EducationForm educationForm);
            public void SetIsMarried(bool IsMarried);
            public void SetIsWorking(bool IsWorking);
            public void AddChild(string SurName, string Name, string MiddleName, DateTime BirthDate, Gender Gender, List<string> Hobbies);
        }
        public enum Gender
        {
            Male,
            Female,
            NonBinary
        }
        public class Child
        {
            public string SurName = "";
            public string Name = "";
            public string MiddleName = "";
            public DateTime BirthDate = DateTime.Now.Date;
            public Gender Gender = Gender.Male;
            public List<string> Hobbies = new List<string>();
            public override string ToString()
            {
                var hobbies = "\n\r\t\t" + String.Join("\n\r\t\t", Hobbies.ToArray());
                return $"{SurName} {Name} {MiddleName}, {BirthDate.ToShortDateString()}, {Gender}, Увлечения: {hobbies}";
            }
            public override bool Equals(object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Child p = (Child)obj;
                    return (SurName == p.SurName) && (Name == p.Name) && (MiddleName == p.MiddleName) && (BirthDate == p.BirthDate);
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(SurName, Name, MiddleName, BirthDate, Gender, Hobbies);
            }
        }
        public enum EducationForm
        {
            FullTime,
            Distance
        }
        public class Student
        {
            public string Name = null;
            public string SurName = null;
            public string MiddleName = null;
            public DateTime? BirthDate = null;
            public bool? IsMarried = null;
            public bool? IsWorking = null;
            public Gender? Gender = null;
            public EducationForm? EducationForm = null;
            public List<Child> Children = null;
            public bool? HaveChild
            {
                get
                {
                    if (Children is null)
                        return null;
                    if (Children.Count > 0)
                        return true;
                    return false;
                }
            }
            public override string ToString()
            {
                var fBirthDate = BirthDate.HasValue ? BirthDate.Value.ToShortDateString() : null;
                var fIsMarried = IsMarried.HasValue ? "Женат/Замжуем: " + (IsMarried.Value ? "Да" : "Нет") : null;
                var fIsWorking = IsWorking.HasValue ? "Работает: " + (IsWorking.Value ? "Да" : "Нет") : null;
                var fHaveChild = HaveChild.HasValue ? "Есть дети: " + (HaveChild.Value ? "Да" : "Нет") : null;
                var fEducationForm = EducationForm.HasValue ? $"Форма обучения: {EducationForm.Value}" : null;
                var fGender = Gender.HasValue ? $"Пол: {Gender.Value}" : null;
                var children = Children is null ? null : "\n\r\t" + String.Join("\n\r\t", Children.Select(c => c.ToString()).ToArray());
                return $"{SurName} {Name} {MiddleName} {fBirthDate} {fGender} {fEducationForm} {fIsMarried} {fIsWorking} {fHaveChild} {children}";
            }
            public override bool Equals(object? obj)
            {
                if ((obj is null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Student p = (Student)obj;
                    return (SurName == p.SurName) && (Name == p.Name) && (MiddleName == p.MiddleName) && (BirthDate == p.BirthDate) && (Gender == p.Gender) && (EducationForm == p.EducationForm);
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(SurName, Name, MiddleName, BirthDate, Gender, EducationForm, IsMarried, Children);
            }
        }
        public class StudentBuilder : IBuilder
        {
            private Student student = new Student();
            public StudentBuilder()
            {
                this.Reset();
            }
            public void SetExistStudent(Student student)
            {
                this.student = student;
            }
            public void Reset()
            {
                this.student = new Student();
            }
            public Student GetStudent()
            {
                var result = this.student;
                return result;
            }
            public Student SaveStudent()
            {
                var result = this.student;
                this.Reset();
                return result;
            }
            public void SetSurName(string SurName)
            {
                student.SurName = SurName;
            }
            public void SetName(string Name)
            {
                student.Name = Name;
            }
            public void SetMiddleName(string MiddleName)
            {
                student.MiddleName = MiddleName;
            }
            public void SetBirthDate(DateTime BirthDate)
            {
                student.BirthDate = BirthDate;
            }
            public void SetGender(Gender Gender)
            {
                student.Gender = Gender;
            }
            public void SetEducationForm(EducationForm EducationForm)
            {
                student.EducationForm = EducationForm;
            }
            public void SetIsMarried(bool IsMarried)
            {
                student.IsMarried = IsMarried;
            }
            public void SetIsWorking(bool IsWorking)
            {
                student.IsWorking = IsWorking;
            }
            public void AddChild(string SurName, string Name, string MiddleName, DateTime BirthDate, Gender Gender, List<string> Hobbies)
            {
                if (student.Children is null)
                    student.Children = new List<Child>();
                student.Children.Add(
                    new Child()
                    {
                        SurName = SurName,
                        Name = Name,
                        MiddleName = MiddleName,
                        BirthDate = BirthDate,
                        Gender = Gender,
                        Hobbies = Hobbies
                    }
                );
            }
            public void RemoveChild(string SomeChildField)
            {
                var findedChild = student.Children.FirstOrDefault(c => c.ToString().Contains(SomeChildField));
                if (findedChild is null)
                    throw new InvalidOperationException("Не был найден ни один ребенок");
                student.Children.Remove(findedChild);
            }
        }
        static void Main(string[] args)
        {
            ConsoleReader();
        }
        public static StudentBuilder ConcreteStudentBuilder = new StudentBuilder();
        public static Dictionary<string, Student> SudentVault = new Dictionary<string, Student>();
        public static void ConsoleReader()
        {
            string input = "";
            while (input != "exit")
            {
                Console.ForegroundColor = ConsoleColor.White;
                HandleCommand(input);
                Console.ResetColor();

                input = Console.ReadLine();

            }
            void HandleCommand(string command)
            {
                var args = command.Split(' ');
                try
                {
                    switch (args[0].ToLower())
                    {
                        case "sname":
                            {
                                Console.WriteLine("Введите фамилию:");
                                ConcreteStudentBuilder.SetSurName(Console.ReadLine());
                                break;
                            }
                        case "name":
                            {
                                Console.WriteLine("Введите имя студента:");
                                ConcreteStudentBuilder.SetName(Console.ReadLine());
                                break;
                            }
                        case "mname":
                            {
                                Console.WriteLine("Введите отчество студента:");
                                ConcreteStudentBuilder.SetMiddleName(Console.ReadLine());
                                break;
                            }
                        case "gen":
                            {
                                Console.WriteLine("Введите пол студента");
                                foreach (var gen in Enum.GetValues(typeof(Gender)))
                                    Console.Write(gen + " ");
                                Console.WriteLine();
                                ConcreteStudentBuilder.SetGender((Gender)Enum.Parse(typeof(Gender), Console.ReadLine()));
                                break;
                            }
                        case "bdate":
                            {
                                Console.WriteLine("Введите дату рождения студента (дд/мм/гггг):");
                                ConcreteStudentBuilder.SetBirthDate(DateTime.Parse(Console.ReadLine()));
                                break;
                            }
                        case "ismar":
                            {
                                Console.WriteLine("Женат/Замжуем? (y/n)(д/н):");
                                var inputIsMarried = Console.ReadLine();
                                ConcreteStudentBuilder.SetIsMarried(inputIsMarried == "y" || inputIsMarried == "д" ? true : false);
                                break;
                            }
                        case "edform":
                            {
                                Console.WriteLine("Введите форму обучения студента");
                                foreach (var ed in Enum.GetValues(typeof(EducationForm)))
                                    Console.Write(ed + " ");
                                Console.WriteLine();
                                ConcreteStudentBuilder.SetEducationForm((EducationForm)Enum.Parse(typeof(EducationForm), Console.ReadLine()));
                                break;
                            }
                        case "iswork":
                            {
                                Console.WriteLine("Работает? (y/n)(д/н):");
                                var inputIsWorking = Console.ReadLine();
                                ConcreteStudentBuilder.SetIsWorking(inputIsWorking == "y" || inputIsWorking == "д" ? true : false);
                                break;
                            }
                        case "addchild":
                            {
                                Console.WriteLine("Введите фамилию ребенка:");
                                var sname = Console.ReadLine();
                                Console.WriteLine("Введите имя ребенка:");
                                var name = Console.ReadLine();
                                Console.WriteLine("Введите отчество ребенка:");
                                var mname = Console.ReadLine();
                                Console.WriteLine("Введите дату рождения ребенка (дд/мм/гггг):");
                                var bdate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Введите пол ребенка ");
                                foreach (var gen in Enum.GetValues(typeof(Gender)))
                                    Console.Write(gen + " ");
                                Console.WriteLine();
                                Gender gender = Gender.Male;
                                bool isValidGender = false;

                                while (!isValidGender)
                                    try
                                    {
                                        gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
                                        isValidGender = true;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }

                                var hobbies = new List<string>();
                                Console.WriteLine("Введите хобби ребенка (exit - чтобы закончить ввод):");
                                var input = Console.ReadLine();
                                while (input != "exit")
                                {
                                    hobbies.Add(input);
                                    input = Console.ReadLine();
                                }

                                ConcreteStudentBuilder.AddChild(sname, name, mname, bdate, gender, hobbies);
                                break;
                            }
                        case "delchild":
                            {
                                Console.WriteLine("Введите фамилию или имя или отчество ребенка которого нужно удалить:");
                                ConcreteStudentBuilder.RemoveChild(Console.ReadLine());
                                break;
                            }
                        case "sh":
                            {
                                Console.WriteLine("Введите идентификатор студента:");
                                Console.WriteLine(SudentVault[Console.ReadLine()]);
                                break;
                            }
                        case "save":
                            {
                                Console.WriteLine("Введите идентификатор студента, чтобы его сохранить:");
                                SudentVault.Add(Console.ReadLine(), ConcreteStudentBuilder.SaveStudent());
                                break;
                            }
                        case "eql":
                            {
                                Console.WriteLine("Введите идентификатор первого студента:");
                                var student1 = SudentVault[Console.ReadLine()];
                                Console.WriteLine("Введите идентификатор второго студента:");
                                var student2 = SudentVault[Console.ReadLine()];
                                Console.WriteLine(student1.Equals(student2) ? "Один и тот же студент" : "Разные студенты");
                                break;
                            }
                        case "set":
                            {
                                Console.WriteLine("Введите идентификатор студента:");
                                ConcreteStudentBuilder.SetExistStudent(SudentVault[Console.ReadLine()]);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(
                                       $"Изменение полей студента\n\r" +
                                       $"\tИзменить фамилию                                  sname\n\r" +
                                       $"\tИзменить имя                                      name\n\r" +
                                       $"\tИзменить отчество                                 mname\n\r" +
                                       $"\tИзменить пол                                      gen\n\r" +
                                       $"\tИзменить дату рождения                            bdate\n\r" +
                                       $"\tИзменить форму обучения                           edform\n\r" +
                                       $"\tИзменить семейное положение                       ismar\n\r" +
                                       $"\tИзменить статус работы                            iswork\n\r" +
                                       $"\tДобавить ребенка студенту                         addchild\n\r" +
                                       $"\tУдалить ребенка у студента                        delchild\n\r\n\r" +
                                       $"Управление студентами\n\r" +
                                       $"\tЗагрузить студента в создатель                    set\n\r" +
                                       $"\tСохранить студента под уникальным идентификатором save\n\r" +
                                       $"\tВывести данные другого студента                   sh\n\r" +
                                       $"\tСравнить студентов                                eql\n\r\n\r" +
                                       $"\tВыход                                             exit\n\r");
                                break;
                            }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Информация о текущем студенте в создателе:\n\r {ConcreteStudentBuilder.GetStudent()}");
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