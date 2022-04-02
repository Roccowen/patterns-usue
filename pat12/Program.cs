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
    public string ToString(int spaceCount);
}

public class Employee : IHasSallary
{
    public string Name { get; set; }
    public int Sallary { get; set; }
    public void IncreaseSallaryBy(int increaseValue) => Sallary += increaseValue;
    public int GetSallary() => Sallary;
    public override string ToString() => $"{Name} ${Sallary}";
    public string ToString(int spaceCount) => $"{new string(' ', spaceCount)}{Name} ${Sallary}";
}

public class Department : IHasSallary
{
    public string Name { get; set; }
    public List<IHasSallary> Employees { get; set; }
    public void IncreaseSallaryBy(int increaseValue) => Employees.ForEach(e => e.IncreaseSallaryBy(increaseValue));
    public int GetSallary() => Employees.Sum(e => e.GetSallary());
    public override string ToString() => $"{Name} ${GetSallary()}:\n\r{String.Join("\n\r", Employees.Select(e => e.ToString()))}";
    public string ToString(int spaceCount) => $"{new string(' ', spaceCount)}{Name} ${GetSallary()}:\n\r{String.Join("\n\r", Employees.Select(e => e.ToString(spaceCount + 1)))}";
}

public class Univerity : IHasSallary, IEnumerable<Employee>
{
    public string Name { get; set; }
    public List<IHasSallary> Departments { get; set; }
    public void IncreaseSallaryBy(int increaseValue) => Departments.ForEach(e => e.IncreaseSallaryBy(increaseValue));
    public int GetSallary() => Departments.Sum(e => e.GetSallary());
    public override string ToString() => $"{Name} ${GetSallary()}:\n\r{String.Join("\n\r", Departments.Select(e => e.ToString()))}";
    public string ToString(int spaceCount) => $"{new string(' ', spaceCount)}{Name} ${GetSallary()}:\n\r{String.Join("\n\r", Departments.Select(e => e.ToString(spaceCount + 1)))}";

    public IEnumerator<Employee> GetEnumerator() => new UniversityIterator(this);

    IEnumerator IEnumerable.GetEnumerator() => new UniversityIterator(this);
}


class UniversityIterator : IEnumerator<Employee>
{
    private IEnumerator<Employee> ItemEnumerator;
    public UniversityIterator(Univerity university)
    {
        ItemEnumerator = GetEmployeesLevels(university)
            .OrderByDescending(s => s.Value)
            .Where(el => el.Key is Employee)
            .Select(e => (Employee)e.Key)
            .GetEnumerator();
    }

    public Employee Current => ItemEnumerator.Current;
    object IEnumerator.Current => ItemEnumerator.Current;

    public bool MoveNext() => ItemEnumerator.MoveNext();

    public void Reset() => ItemEnumerator.Reset();

    private Dictionary<IHasSallary, int> GetEmployeesLevels(Univerity university)
    {
        var objsLevels = new Dictionary<IHasSallary, int>();
        NextLevel(university);
        return objsLevels;

        void NextLevel(IHasSallary obj, int level = 0)
        {
            if (obj is Employee)
                objsLevels.Add(obj, level);
            else
            {
                objsLevels.Add(obj, level);

                if (obj is Univerity)
                    (obj as Univerity).Departments.ForEach(e => NextLevel(e, level + 1));

                if (obj is Department)
                    (obj as Department).Employees.ForEach(e => NextLevel(e, level + 1));
            }
        }
    }
    public void Dispose() { }
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
                            Name = "Сотрудник 12",
                            Sallary = 3700,
                        },
                    }
                },
            }
    };

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
                        Console.WriteLine("Введите число на которое необходимо изменить зарплату сотрудникам:");
                        university.IncreaseSallaryBy(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case "2":
                        Console.WriteLine("Введите число на которое необходимо изменить зарплату сотрудникам:");
                        var sallaryIncerease = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\r{string.Join("\n\r", university.Select(employee => $"  {employee.Name} ${employee.Sallary} -> ${employee.Sallary += sallaryIncerease}"))}\n\r");
                        break;
                    case "exit":
                        return;
                    default:
                        {
                            Console.WriteLine(
                                   $"Управление документами \n\r" +
                                   $"\tИзменить всем зарплату рекурсивно                1\n\r" +
                                   $"\tИзменить всем зарплату начиная с нижнего уровня  2\n\r" +
                                   $"Выход                       exit\n\r");
                            break;
                        }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(university.ToString(1));
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