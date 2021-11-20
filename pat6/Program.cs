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
        public abstract class Employee : IClonable
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
            public abstract Employee Clone();
            public override string ToString()
            {
                return $"{this.GetType().Name} {Surname} {Name} {Middlename} {BDate} ${Sallary}";
            }
        }
        public abstract class AbstractIntern : Employee
        {
            public AbstractIntern()
            {

            }
            public AbstractIntern(AbstractIntern a) : base(a)
            {

            }
        }
        public abstract class AbstractClerk : Employee
        {
            public AbstractClerk()
            {

            }
            public AbstractClerk(AbstractClerk a) : base(a)
            {

            }
        }
        public abstract class AbstractDeputyHead : Employee
        {
            public AbstractDeputyHead()
            {

            }
            public AbstractDeputyHead(AbstractDeputyHead a) : base(a)
            {

            }
        }
        public abstract class AbstractHead : Employee
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
            public override HRIntern Clone()
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
            public override HRClerk Clone()
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
            public override HRDeputyHead Clone()
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
            public override HRHead Clone()
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
            public override FinanceIntern Clone()
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
            public override FinanceClerk Clone()
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
            public override FinanceDeputyHead Clone()
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
            public override FinanceHead Clone()
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
            public override LearnIntern Clone()
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
            public override LearnClerk Clone()
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
            public override LearnDeputyHead Clone()
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
            public override LearnHead Clone()
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
            public override InternationalIntern Clone()
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
            public override InternationalClerk Clone()
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
            public override InternationalDeputyHead Clone()
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
            public override InternationalHead Clone()
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
                            return builder.CreateIntern(name, surname, middlename, bdate, summary);
                        case "clerk":
                            return builder.CreateClerk(name, surname, middlename, bdate, summary);
                        case "deputyhead":
                            return builder.CreateDeputyHead(name, surname, middlename, bdate, summary);
                        case "head":
                            return builder.CreateHead(name, surname, middlename, bdate, summary);
                        default:
                            throw new ArgumentException("Нет подходящей должности");
                    }
                }
                try
                {
                    switch (command)
                    {
                        case "copy":
                            {
                                Employees.Keys.ToList().ForEach(e => Console.WriteLine($"{e} - {Employees[e]}"));
                                Console.WriteLine("Введите уникальный идентификатор сотрудника которого скопировать:");
                                var key = Console.ReadLine();
                                Console.WriteLine("Введите уникальный идентификатор новго сотрудника:");
                                var keyNew = Console.ReadLine();
                                Employees.Add(keyNew, Employees[key].Clone());
                                break;
                            }
                        case "chng":
                            {
                                Employees.Keys.ToList().ForEach(e => Console.WriteLine($"{e} - {Employees[e]}"));
                                Console.WriteLine("Введите уникальный идентификатор сотрудника которого изменить:");
                                string key = Console.ReadLine();                             
                                string cmd = !Employees.ContainsKey(key) ? throw new ArgumentException("Сотрудника с таким ключом не существует!") : "";
                                while (cmd != "exit")
                                {
                                    switch (cmd)
                                    {
                                        case "name":
                                            {
                                                Console.WriteLine("Введите имя сотрудника:");
                                                Employees[key].Name = Console.ReadLine();
                                                Console.WriteLine(Employees[key]);
                                                break;
                                            }
                                        case "sname":
                                            {
                                                Console.WriteLine("Введите фамилию сотрудника:");
                                                Employees[key].Surname = Console.ReadLine();
                                                Console.WriteLine(Employees[key]);
                                                break;
                                            }
                                        case "mname":
                                            {
                                                Console.WriteLine("Введите отчество сотрудника:");
                                                Employees[key].Middlename = Console.ReadLine();
                                                Console.WriteLine(Employees[key]);
                                                break;
                                            }
                                        case "pay":
                                            {
                                                Console.WriteLine("Введите зарплату сотрудника:");
                                                Employees[key].Sallary = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine(Employees[key]);
                                                break;
                                            }
                                        case "bdate":
                                            {
                                                Console.WriteLine("Введите дату рождения сотрудника:");
                                                Employees[key].BDate = Console.ReadLine();
                                                Console.WriteLine(Employees[key]);
                                                break;
                                            }
                                        default:
                                            Console.WriteLine(
                                              $"Изменить имя            name\n\r" +
                                              $"Изменить фамилию        sname\n\r" +
                                              $"Изменить фамилию        mname\n\r" +
                                              $"Изменить зп             pay\n\r" +
                                              $"Изменить дату рождения  bdate\n\r\n\r" +
                                              $"Выход                   exit\n\r");
                                            break;
                                    }
                                    cmd = Console.ReadLine();
                                }
                                break;
                            }
                        case "crt":
                            {
                                Console.WriteLine("Введите название отдела");
                                Console.WriteLine("learn, international, hr, finance");
                                var depart = Console.ReadLine();
                                while (depart != "learn" && depart != "international" && depart != "hr" && depart != "finance")
                                    depart = Console.ReadLine();
                                Console.WriteLine("Введите название должности");
                                Console.WriteLine("intern, clerk, deputyhead, head");
                                var rang = Console.ReadLine();
                                while (rang != "intern" && rang != "clerk" && rang != "deputyhead" && rang != "head")
                                    rang = Console.ReadLine();
                                Console.WriteLine("Введите фамилию нового сотрудника");
                                var surname = Console.ReadLine();
                                Console.WriteLine("Введите имя нового сотрудника");
                                var name = Console.ReadLine();
                                Console.WriteLine("Введите отчество нового сотрудника");
                                var middleName = Console.ReadLine();
                                Console.WriteLine("Введите дату рождения нового сотрудника");
                                var bdate = Console.ReadLine();
                                Console.WriteLine("Введите зарплату нового сотрудника");
                                var payment = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите уникальный идентификатор нового сотрудника");
                                var key = Console.ReadLine();
                                AbstractEmployeeBuilder builder = null;
                                switch (depart)
                                {
                                    case "learn":
                                        builder = LearnBuilder;
                                        break;
                                    case "international":
                                        builder = InternationalBuilder;
                                        break;
                                    case "hr":
                                        builder = HRBuilder;
                                        break;
                                    case "finance":
                                        builder = FinanceBuilder;
                                        break;
                                    default:
                                        break;
                                }
                                Employees.Add(key, CreateEmployee(builder, rang, surname, name, middleName, bdate, payment));
                                break;
                            }
                        case "sha":
                            {
                                Employees.Keys.ToList().ForEach(e => Console.WriteLine($"{e} - {Employees[e]}"));
                                break;
                            }
                        case "sh":
                            {
                                Console.WriteLine("Введите название отдела или должности сотрудника:");
                                Console.WriteLine("learn, international, hr, finance");
                                Console.WriteLine("intern, clerk, deputyhead, head");
                                switch (Console.ReadLine().ToLower())
                                {
                                    case "learn":
                                        Employees.Values.Where(e => e is LearnDepartment)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "international":
                                        Employees.Values.Where(e => e is InternationalDepartment)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "hr":
                                        Employees.Values.Where(e => e is HRDepartment)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "finance":
                                        Employees.Values.Where(e => e is FinanceDepartment)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "intern":
                                        Employees.Values.Where(e => e is AbstractIntern)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "clerk":
                                        Employees.Values.Where(e => e is AbstractClerk)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "deputyhead":
                                        Employees.Values.Where(e => e is AbstractDeputyHead)
                                            .ToList()
                                            .ForEach(e => Console.WriteLine(e));
                                        break;
                                    case "head":
                                        Employees.Values.Where(e => e is AbstractHead)
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
                                  $"Скопировать сотрудникка                                     copy\n\r" +
                                  $"Изменить сотрудника                                         chng\n\r" +
                                  $"Вывод всех сотрудников определенной должности или отдела    sh\n\r" +
                                  $"Вывод всех текущих сотрудников                              sha\n\r" +
                                  $"Создать сотрудника                                          crt\n\r" +
                                  $"Выход                                                       exit\n\r");
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