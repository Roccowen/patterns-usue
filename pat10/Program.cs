using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public Student(string lastName, string firstName, string patronomyc)
    {
        LastName = lastName;
        FirstName = firstName;
        Patronomyc = patronomyc;
    }
    public string Patronomyc { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student Copy()
    {
        return new Student(LastName, FirstName, Patronomyc);
    }
    public override string ToString() => $"{LastName} {FirstName} {Patronomyc}";
    public override bool Equals(object? obj)
    {
        return obj is Student student &&
               Patronomyc == student.Patronomyc &&
               FirstName == student.FirstName &&
               LastName == student.LastName;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Patronomyc, FirstName, LastName);
    }
}

public class GroupRepository
{
    private List<Group> Groups = new List<Group>()
    {
        new Group() { Name = "ЭМА-18-1" },
        new Group() { Name = "ЭМА-18-2" }
    };

    public Student GetStudent(int groupId, int studentId) => Groups[groupId - 1].Students[studentId - 1].Copy();
    public void AddStudent(int groupId, Student student) => Groups[groupId - 1].Students.Add(student);
    public void RemoveStudent(int groupId, Student student) => Groups[groupId - 1].Students.Remove(student);
    public override string ToString() => $"{String.Join("\n\r", Enumerable.Range(1, Groups.Count).Zip(Groups, (number, group) => $"{number}. {group}"))}";

    class Group
    {
        public string Name { get; set; }
        public List<Student> Students = new List<Student>();
        public override string ToString() 
        {
            return $"{Name}{(Students.Count > 0 ? $":\n\r\t{String.Join("\n\r\t", Enumerable.Range(1, Students.Count).Zip(Students, (number, student) => $"{number}. {student}"))}" : String.Empty)}";
        }
    }
}

public interface ICommand
{
    void Execute();
}

public class AddStudentCommand : ICommand
{
    GroupRepository GroupRepository;
    public AddStudentCommand(GroupRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine("Введите фамилию нового студента:");
        var lastName = Console.ReadLine();

        Console.WriteLine("Введите имя нового студента:");
        var firstName = Console.ReadLine();

        Console.WriteLine("Введите отчество нового студента:");
        var patronomyc = Console.ReadLine();

        Console.WriteLine(GroupRepository);
        Console.WriteLine("Введите номер группы в которую необходимо добавить студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.AddStudent(groupId, new Student(lastName, firstName, patronomyc));
    }
}

public class RemoveStudentCommand : ICommand
{
    GroupRepository GroupRepository;
    public RemoveStudentCommand(GroupRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository);
        Console.WriteLine("Введите номер группы в которой необходимо удалить студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите номер студента, которого необходимо удалить.");
        var studentId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.RemoveStudent(groupId, GroupRepository.GetStudent(groupId, studentId));
    }
}

public class CutStudentCommand : ICommand
{
    GroupRepository GroupRepository;
    public CutStudentCommand(GroupRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository);
        Console.WriteLine("Введите номер группы из которой необходмо перенести студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите номер студента, которого необходимо перенести.");
        var studentId = Convert.ToInt32(Console.ReadLine());

        var cutedStudent = GroupRepository.GetStudent(groupId, studentId);
        GroupRepository.RemoveStudent(groupId, cutedStudent);

        Console.WriteLine("Введите номер группы в которую необходмо перенести студента.");
        var newGroupId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.AddStudent(newGroupId, cutedStudent);
    }
}

public class CopyStudentCommand : ICommand
{
    GroupRepository GroupRepository;
    public CopyStudentCommand(GroupRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository);
        Console.WriteLine("Введите номер группы из которой необходмо скопировать студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите номер студента, которого необходимо скопировать.");
        var studentId = Convert.ToInt32(Console.ReadLine());

        var copiedStudent = GroupRepository.GetStudent(groupId,studentId).Copy();

        Console.WriteLine("Введите номер группы в которую необходмо скопировать студента.");
        var newGroupId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.AddStudent(newGroupId, copiedStudent);
    }
}

public class ShowRepositoryCommand : ICommand
{
    GroupRepository GroupRepository;
    public ShowRepositoryCommand(GroupRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository);
    }
}

public class ConsoleReader
{
    ICommand AddCommand;
    ICommand RemoveCommand;
    ICommand CutCommand;
    ICommand CopyCommand;
    ICommand ShowCommand;

    public ConsoleReader(ICommand AddCommand, ICommand RemoveCommand, ICommand CutCommand, ICommand CopyCommand, ICommand ShowCommand)
    {
        this.AddCommand = AddCommand;
        this.RemoveCommand = RemoveCommand;
        this.CutCommand = CutCommand;
        this.CopyCommand = CopyCommand;
        this.ShowCommand = ShowCommand;
    }

    public void Run()
    {
        Console.WriteLine("Для появления справки нажмите - Enter...");
        while (true)
        {
            try
            {
                var command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "e":
                        AddCommand.Execute();
                        break;
                    case "d":
                        RemoveCommand.Execute();
                        break;
                    case "c":
                        CopyCommand.Execute();
                        break;
                    case "x":
                        CutCommand.Execute();
                        break;
                    case "exit":
                        return;
                    default:
                        {
                            Console.WriteLine(
                                   $"Управление студентами\n\r" +
                                   $"\tДобавить студента        E\n\r" +
                                   $"\tУдалить студента         D\n\r" +
                                   $"\tСкопировать студента     C\n\r" +
                                   $"\tПереместить студента     X\n\r" +

                                   $"\n\rВыход                      exit\n\r");
                            break;
                        }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                ShowCommand.Execute();
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

public static class Programm
{   
    public static void Main(string[] args)
    {
        var repo = new GroupRepository();
        
        var reader = new ConsoleReader(
            new AddStudentCommand(repo), 
            new RemoveStudentCommand(repo), 
            new CutStudentCommand(repo), 
            new CopyStudentCommand(repo), 
            new ShowRepositoryCommand(repo));
        
        reader.Run();
    }
}