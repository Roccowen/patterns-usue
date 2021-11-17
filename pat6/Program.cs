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
        public abstract class AbstractEmployee
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Middlename { get; set; }
            public string BDate { get; set; }
            public int Sallary { get; set; }
            public override string ToString()
            {
                return $"{this.GetType().Name} {Surname} {Name} {Middlename} {BDate} ${Sallary}";
            }
        }
        public abstract class AbstractIntern : AbstractEmployee
        {

        }
        public abstract class AbstractClerk : AbstractEmployee
        {

        }
        public abstract class AbstractDeputyHead : AbstractEmployee
        {

        }
        public abstract class AbstractHead : AbstractEmployee
        {

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

        }
        class HRClerk : AbstractClerk, HRDepartment
        {

        }
        class HRDeputyHead : AbstractDeputyHead, HRDepartment
        {

        }
        class HRHead : AbstractHead, HRDepartment
        {

        }
        class FinanceIntern : AbstractIntern, FinanceDepartment
        {

        }
        class FinanceClerk : AbstractClerk, FinanceDepartment
        {

        }
        class FinanceDeputyHead : AbstractDeputyHead, FinanceDepartment
        {

        }
        class FinanceHead : AbstractHead, FinanceDepartment
        {

        }
        class LearnIntern : AbstractIntern, LearnDepartment
        {

        }
        class LearnClerk : AbstractClerk, LearnDepartment
        {

        }
        class LearnDeputyHead : AbstractDeputyHead, LearnDepartment
        {

        }
        class LearnHead : AbstractHead, LearnDepartment
        {

        }
        class InternationalIntern : AbstractIntern, InternationalDepartment
        {

        }
        class InternationalClerk : AbstractClerk, InternationalDepartment
        {

        }
        class InternationalDeputyHead : AbstractDeputyHead, InternationalDepartment
        {

        }
        class InternationalHead : AbstractHead, InternationalDepartment
        {

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
        public static List<AbstractEmployee> Employees = new List<AbstractEmployee>();
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
                AbstractEmployee CreateEmployee(AbstractEmployeeBuilder builder, string job, string surname, string name, string middlename, string bdate, int summary)
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
                var args = command.Split(' ');
                try
                {
                    switch (args[0].ToLower())
                    {
                        case "crt":
                            {
                                switch (args[1].ToLower())
                                {
                                    case "hr":
                                        Employees.Add(
                                            CreateEmployee(HRBuilder, args[2].ToLower(), args[3], args[4], args[5], args[6], Convert.ToInt32(args[7])));
                                        break;
                                    case "learn":
                                        Employees.Add(
                                            CreateEmployee(LearnBuilder, args[2].ToLower(), args[3], args[4], args[5], args[6], Convert.ToInt32(args[7])));
                                        break;
                                    case "international":
                                        Employees.Add(
                                            CreateEmployee(InternationalBuilder, args[2].ToLower(), args[3], args[4], args[5], args[6], Convert.ToInt32(args[7])));
                                        break;
                                    case "finance":
                                        Employees.Add(
                                            CreateEmployee(FinanceBuilder, args[2].ToLower(), args[3], args[4], args[5], args[6], Convert.ToInt32(args[7])));
                                        break;
                                    default:
                                        throw new ArgumentException("Нет подходящего отдела");
                                }
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
                        default:
                            {
                                Console.WriteLine(
                                  $"Названия отделов: learn, international, hr, finance\n\r" +
                                  $"Названия должностей: intern, clerk, deputyhead, head\n\r\n\r" +
                                  $"Вывод всех текущих сотрудников определенного отдела   sh \"Название отдела\"\n\r" +
                                  $"Вывод всех текущих сотрудников определенной должности sh \"Название должности\"\n\r" +
                                  $"Создать сотрудника                                    crt \"Название отдела\" \"Название должности\" <Фамилия> <Имя> <Отчество> <Дата рождения> <Зарплата >\n\r" +
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