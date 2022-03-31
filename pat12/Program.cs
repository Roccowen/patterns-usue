using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IHasSallary
{
    public void IncreaseSallaryBy(int increaseValue);
    public int GetSallary();
}

public class Employee : IHasSallary
{
    public string Name { get; set; }
    public int Sallary { get; set; }
    public void IncreaseSallaryBy(int increaseValue) => Sallary += increaseValue;
    public int GetSallary() => Sallary;
    public override string ToString() => $"{Name} ${Sallary}";
}

public class Department : IHasSallary
{
    public string Name { get; set; }
    public List<IHasSallary> Employees { get; set; }
    public void IncreaseSallaryBy(int increaseValue) => Employees.ForEach(e => e.IncreaseSallaryBy(increaseValue));
    public int GetSallary() => Employees.Sum(e => e.GetSallary());
    public override string ToString() => $"{Name} ${GetSallary()}:\n\r{String.Join("\n\r", Employees.Select(e => e.ToString()))}";
}

public class Univerity : IHasSallary, IEnumerable
{
    public string Name { get; set; }
    public List<IHasSallary> Departments { get; set; }
    public void IncreaseSallaryBy(int increaseValue) => Departments.ForEach(e => e.IncreaseSallaryBy(increaseValue));
    public int GetSallary() => Departments.Sum(e => e.GetSallary());
    public override string ToString() => $"{Name} ${GetSallary()}:\n\r{String.Join("\n\r", Departments.Select(e => e.ToString()))}";
    public IEnumerator GetEnumerator() => new UniversityIterator(this);
}

public static class Extention
{
    public static IEnumerable<T> Traverse<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> childSelector)
    {
        var stack = new Stack<T>(items);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (var child in childSelector(next))
                stack.Push(child);
        }
    }
}

class UniversityIterator : IEnumerator
{
    public IHasSallary Current;
    private Univerity Univerity;
    private Dictionary<IHasSallary, int> ItemsLevels = new Dictionary<IHasSallary, int>();

    object IEnumerator.Current => throw new NotImplementedException();

    public UniversityIterator(Univerity university)
    {
        Univerity = university;
    }

    public List<IHasSallary> Magic(Univerity _univerity)
    {
        var list = new List<IHasSallary>();
        
        void GetEmployee(IHasSallary obj)
        {
            if (obj is Univerity)
                (obj as Univerity).Departments.ForEach(e => GetEmployee(e));
            else if (obj is Department)
                (obj as Department).Employees.ForEach(e => GetEmployee(e));
            else 
                list.Add(obj);
        }
        GetEmployee(_univerity);
        return list;
    }


    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}

public static class Program
{
    public static Univerity university = new Univerity()
    {
        Name = "Университет",
        Departments = new List<IHasSallary>()
            {
                new Department()
                {
                    Name = "УМУ",
                    Employees = new List<IHasSallary>()
                    {
                        new Department()
                        {
                            Name = "Учебный отдел",
                            Employees = new List<IHasSallary>()
                            {
                                new Employee()
                                {
                                    Name = "Сотрудник 1",
                                    Sallary = 1000,
                                },
                                new Employee()
                                {
                                    Name = "Сотрудник 2",
                                    Sallary = 2000,
                                },
                                new Employee()
                                {
                                    Name = "Сотрудник 3",
                                    Sallary = 3000,
                                },
                            }
                        },
                        new Department()
                        {
                            Name = "Отдел по работе с ОП",
                            Employees = new List<IHasSallary>()
                            {
                                new Employee()
                                {
                                    Name = "Сотрудник 4",
                                    Sallary = 4400,
                                },
                                new Employee()
                                {
                                    Name = "Сотрудник 5",
                                    Sallary = 3200,
                                },
                            }
                        },
                    }
                },
                new Department()
                {
                    Name = "ПФУ",
                    Employees = new List<IHasSallary>()
                    {
                        new Employee()
                        {
                            Name = "Сотрудник 6",
                            Sallary = 1000,
                        },
                        new Employee()
                        {
                            Name = "Сотрудник 7",
                            Sallary = 2900,
                        },
                        new Department()
                        {
                            Name = "Бухгалтерия",
                            Employees = new List<IHasSallary>()
                            {
                                new Employee()
                                {
                                    Name = "Сотрудник 8",
                                    Sallary = 1000,
                                },
                                new Employee()
                                {
                                    Name = "Сотрудник 9",
                                    Sallary = 2000,
                                },

                            }
                        },
                    }
                },
                new Department()
                {
                    Name = "ОК",
                    Employees = new List<IHasSallary>()
                    {
                        new Employee()
                        {
                            Name = "Сотрудник 10",
                            Sallary = 5200,
                        },
                        new Employee()
                        {
                            Name = "Сотрудник 11",
                            Sallary = 1200,
                        },
                        new Employee()
                        {
                            Name = "Сотрудник12",
                            Sallary = 3700,
                        },
                    }
                },
            }
    };

    static void Main(string[] args)
    {
        var iterator = new UniversityIterator(university);
        var a = iterator.Magic(university);
        Console.WriteLine();
    } //=> ConsoleReader();
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
                        Console.WriteLine("Введите число на которое необходимо изменить зарплату сотрудникам:");
                        university.IncreaseSallaryBy(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "exit":
                        return;
                    default:
                        {
                            Console.WriteLine(
                                   $"Управление документами \n\r" +
                                   $"\tИзменить всем зарплату         1\n\r" +
                                   $"Выход                       exit\n\r");
                            break;
                        }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(university);
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