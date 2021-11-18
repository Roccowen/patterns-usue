using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pat6
{
    class Program
    {
        public abstract class AbstractEmployeeBuilder
        {
            public abstract AbstractIntern CreateIntern(string name, string surname, string middlename, string bdate, int sallary);
            public abstract AbstractClerk CreateClerk(string name, string surname, string middlename, string bdate, int sallary);
            public abstract AbstractDeputyHead CreateDeputyHead(string name, string surname, string middlename, string bdate, int sallary);
            public abstract AbstractHead CreateHead(string name, string surname, string middlename, string bdate, int sallary);
        }
        public class HREmployeeBuilder : AbstractEmployeeBuilder
        {
            public override AbstractClerk CreateClerk(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new HRClerk()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractDeputyHead CreateDeputyHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new HRDeputyHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractHead CreateHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new HRHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractIntern CreateIntern(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new HRIntern()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
        }
        public class FinanceEmployeeBuilder : AbstractEmployeeBuilder
        {
            public override AbstractClerk CreateClerk(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new FinanceClerk()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractDeputyHead CreateDeputyHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new FinanceDeputyHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractHead CreateHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new FinanceHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractIntern CreateIntern(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new FinanceIntern()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
        }
        public class InternationalEmployeeBuilder : AbstractEmployeeBuilder
        {
            public override AbstractClerk CreateClerk(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new InternationalClerk()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractDeputyHead CreateDeputyHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new InternationalDeputyHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractHead CreateHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new InternationalHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractIntern CreateIntern(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new InternationalIntern()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
        }
        public class LearnEmployeeBuilder : AbstractEmployeeBuilder
        {
            public override AbstractClerk CreateClerk(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new LearnClerk()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractDeputyHead CreateDeputyHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new LearnDeputyHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractHead CreateHead(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new LearnHead()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
            public override AbstractIntern CreateIntern(string name, string surname, string middlename, string bdate, int sallary)
            {
                return new LearnIntern()
                {
                    Name = name,
                    Surname = surname,
                    Middlename = middlename,
                    BDate = bdate,
                    Sallary = sallary,
                };
            }
        }
        public interface IClonable
        {
            public Employee Clone();
        }
        public class Employee : IClonable
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Middlename { get; set; }
            public string BDate { get; set; }
            public int Sallary { get; set; }
            public Employee()
            {

            }
            public Employee(Employee employee)
            {
                Name = employee.Name;
                Surname = employee.Surname;
                Middlename = employee.Middlename;
                BDate = employee.BDate;
                Sallary = employee.Sallary;
            }
            public Employee Clone()
            {
                return new Employee(this);
            }
            public override string ToString()
            {
                return $"{this.GetType().Name} {Surname} {Name} {Middlename} {BDate} ${Sallary}";
            }
        }
        public class AbstractIntern : Employee
        {
            public AbstractIntern()
            {

            }
            public AbstractIntern(AbstractIntern a) : base(a)
            {

            }
        }
        public class AbstractClerk : Employee
        {
            public AbstractClerk()
            {

            }
            public AbstractClerk(AbstractClerk a) : base(a)
            {

            }
        }
        public class AbstractDeputyHead : Employee
        {
            public AbstractDeputyHead()
            {

            }
            public AbstractDeputyHead(AbstractDeputyHead a) : base(a)
            {

            }
        }
        public class AbstractHead : Employee
        {
            public AbstractHead()
            {

            }
            public AbstractHead(AbstractHead a) : base(a)
            {

            }
        }
        interface AbstractDepartment
        {

        }
        interface HRDepartment : AbstractDepartment
        {

        }
        interface FinanceDepartment : AbstractDepartment
        {

        }
        interface LearnDepartment : AbstractDepartment
        {

        }
        interface InternationalDepartment : AbstractDepartment
        {

        }
        class HRIntern : AbstractIntern, HRDepartment
        {
            public HRIntern()
            {

            }
            public HRIntern(HRIntern a) : base(a)
            {

            }
            public new HRIntern Clone()
            {
                return new HRIntern(this);
            }
        }
        class HRClerk : AbstractClerk, HRDepartment
        {
            public HRClerk()
            {

            }
            public HRClerk(HRClerk a) : base(a)
            {

            }
            public new HRClerk Clone()
            {
                return new HRClerk(this);
            }
        }
        class HRDeputyHead : AbstractDeputyHead, HRDepartment
        {
            public HRDeputyHead()
            {

            }
            public HRDeputyHead(HRDeputyHead a) : base(a)
            {

            }
            public new HRDeputyHead Clone()
            {
                return new HRDeputyHead(this);
            }
        }
        class HRHead : AbstractHead, HRDepartment
        {
            public HRHead()
            {

            }
            public HRHead(HRHead a) : base(a)
            {

            }
            public new HRHead Clone()
            {
                return new HRHead(this);
            }
        }
        class FinanceIntern : AbstractIntern, FinanceDepartment
        {
            public FinanceIntern()
            {

            }
            public FinanceIntern(FinanceIntern a) : base(a)
            {

            }
            public new FinanceIntern Clone()
            {
                return new FinanceIntern(this);
            }
        }
        class FinanceClerk : AbstractClerk, FinanceDepartment
        {
            public FinanceClerk()
            {

            }
            public FinanceClerk(FinanceClerk a) : base(a)
            {

            }
            public new FinanceClerk Clone()
            {
                return new FinanceClerk(this);
            }
        }
        class FinanceDeputyHead : AbstractDeputyHead, FinanceDepartment
        {
            public FinanceDeputyHead()
            {

            }
            public FinanceDeputyHead(FinanceDeputyHead a) : base(a)
            {

            }
            public new FinanceDeputyHead Clone()
            {
                return new FinanceDeputyHead(this);
            }
        }
        class FinanceHead : AbstractHead, FinanceDepartment
        {
            public FinanceHead()
            {

            }
            public FinanceHead(FinanceHead a) : base(a)
            {

            }
            public new FinanceHead Clone()
            {
                return new FinanceHead(this);
            }
        }
        class LearnIntern : AbstractIntern, LearnDepartment
        {
            public LearnIntern()
            {

            }
            public LearnIntern(LearnIntern a) : base(a)
            {

            }
            public new LearnIntern Clone()
            {
                return new LearnIntern(this);
            }
        }
        class LearnClerk : AbstractClerk, LearnDepartment
        {
            public LearnClerk()
            {

            }
            public LearnClerk(LearnClerk a) : base(a)
            {

            }
            public new LearnClerk Clone()
            {
                return new LearnClerk(this);
            }
        }
        class LearnDeputyHead : AbstractDeputyHead, LearnDepartment
        {
            public LearnDeputyHead()
            {

            }
            public LearnDeputyHead(LearnDeputyHead a) : base(a)
            {

            }
            public new LearnDeputyHead Clone()
            {
                return new LearnDeputyHead(this);
            }
        }
        class LearnHead : AbstractHead, LearnDepartment
        {
            public LearnHead()
            {

            }
            public LearnHead(LearnHead a) : base(a)
            {

            }
            public new LearnHead Clone()
            {
                return new LearnHead(this);
            }
        }
        class InternationalIntern : AbstractIntern, InternationalDepartment
        {
            public InternationalIntern()
            {

            }
            public InternationalIntern(InternationalIntern a) : base(a)
            {

            }
            public new InternationalIntern Clone()
            {
                return new InternationalIntern(this);
            }
        }
        class InternationalClerk : AbstractClerk, InternationalDepartment
        {
            public InternationalClerk()
            {

            }
            public InternationalClerk(InternationalClerk a) : base(a)
            {

            }
            public new InternationalClerk Clone()
            {
                return new InternationalClerk(this);
            }
        }
        class InternationalDeputyHead : AbstractDeputyHead, InternationalDepartment
        {
            public InternationalDeputyHead()
            {

            }
            public InternationalDeputyHead(InternationalDeputyHead a) : base(a)
            {

            }
            public new InternationalDeputyHead Clone()
            {
                return new InternationalDeputyHead(this);
            }
        }
        class InternationalHead : AbstractHead, InternationalDepartment
        {
            public InternationalHead()
            {

            }
            public InternationalHead(InternationalHead a) : base(a)
            {

            }
            public new InternationalHead Clone()
            {
                return new InternationalHead(this);
            }
        }

        static void Main(string[] args)
        {
            ConsoleReader();
        }
        private static HREmployeeBuilder hrBuilder;
        public static HREmployeeBuilder HRBuilder
        {
            get
            {
                if (hrBuilder is null)
                    hrBuilder = new HREmployeeBuilder();
                return hrBuilder;
            }
        }
        private static FinanceEmployeeBuilder financeBuilder;
        public static FinanceEmployeeBuilder FinanceBuilder
        {
            get
            {
                if (financeBuilder is null)
                    financeBuilder = new FinanceEmployeeBuilder();
                return financeBuilder;
            }
        }
        private static InternationalEmployeeBuilder internationalBuilder;
        public static InternationalEmployeeBuilder InternationalBuilder
        {
            get
            {
                if (internationalBuilder is null)
                    internationalBuilder = new InternationalEmployeeBuilder();
                return internationalBuilder;
            }
        }
        private static LearnEmployeeBuilder learnBuilder;
        public static LearnEmployeeBuilder LearnBuilder
        {
            get
            {
                if (learnBuilder is null)
                    learnBuilder = new LearnEmployeeBuilder();
                return learnBuilder;
            }
        }
        public static Dictionary<string, Employee> Employees = new Dictionary<string, Employee>();
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
                Employee CreateEmployee(AbstractEmployeeBuilder builder, string job, string surname, string name, string middlename, string bdate, int summary)
                {
                    switch (job)
                    {
                        case "intern":
                            return builder.CreateIntern(surname, name, middlename, bdate, summary);
                        case "clerk":
                            return builder.CreateClerk(surname, name, middlename, bdate, summary);
                        case "deputyhead":
                            return builder.CreateDeputyHead(surname, name, middlename, bdate, summary);
                        case "head":
                            return builder.CreateHead(surname, name, middlename, bdate, summary);
                        default:
                            throw new ArgumentException("Нет подходящей должности");
                    }
                }
                try
                {
                    switch (command)
                    {
                        case "crt":
                            {
                                Console.WriteLine("Введите название отдела");
                                Console.WriteLine("learn, international, hr, finance");
                                var depart = Console.ReadLine();
                                Console.WriteLine("Введите название должности");
                                Console.WriteLine("intern, clerk, deputyhead, head");
                                var rang = Console.ReadLine();
                                Console.WriteLine("Введите фамилию нового сотрудника");
                                var surname = Console.ReadLine();
                                Console.WriteLine("Введите имя нового сотрудника");
                                var name = Console.ReadLine();
                                Console.WriteLine("Введите отчество нового сотрудника");
                                var middleName = Console.ReadLine();
                                Console.WriteLine("Введите дату рождения нового сотрудника");
                                var bdate = Console.ReadLine();
                                Console.WriteLine("Введите зарплату нового сотрудника");
                                var payment = Console.ReadLine();

                                
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
                        case "sh":
                            {
                                if (args.Length == 1)
                                    Employees.ForEach(e => Console.WriteLine(e));
                                if (args.Length == 2)
                                    switch (args[1].ToLower())
                                    {
                                        case "learn":
                                            Employees.Where(e => e is LearnDepartment)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "international":
                                            Employees.Where(e => e is InternationalDepartment)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "hr":
                                            Employees.Where(e => e is HRDepartment)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "finance":
                                            Employees.Where(e => e is FinanceDepartment)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "intern":
                                            Employees.Where(e => e is AbstractIntern)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "clerk":
                                            Employees.Where(e => e is AbstractClerk)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "deputyhead":
                                            Employees.Where(e => e is AbstractDeputyHead)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        case "head":
                                            Employees.Where(e => e is AbstractHead)
                                                .ToList()
                                                .ForEach(e => Console.WriteLine(e));
                                            break;
                                        default:
                                            throw new ArgumentException("Не существует подходящего отдела или должности");
                                    }
                                break;
                            }
                        case "ch":
                            {
                                break;
                            }
                        case "cln":
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(
                                  $"Названия отделов: learn, international, hr, finance\n\r" +
                                  $"Названия должностей: intern, clerk, deputyhead, head\n\r\n\r" +
                                  $"Скопировать сотрудникка\n\r" +
                                  $"Вывод всех текущих сотрудников определенного отдела   sh \"Название отдела\"\n\r" +
                                  $"Вывод всех текущих сотрудников определенной должности sh \"Название должности\"\n\r" +
                                  $"Создать сотрудника                                    crt \"Название отдела\" \"Название должности\" <Фамилия> <Имя> <Отчество> <Дата рождения> <Зарплата>\n\r" +
                                  $"Вывод всех текущих сотрудников                        sh\n\r" +
                                  $"Выход                                                 exit\n\r");
                            }
                            break;
                    }
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