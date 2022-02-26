using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IMomento
{

}

public interface ICommand
{
    void Execute();
}

public interface IStudentRepository
{
    public Student GetStudent(int groupId, int studentId);
    public void AddStudent(int groupId, Student student);
    public void RemoveStudent(int groupId, Student student);
    public string RepositoryToString();
    public void Undo();
}

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

public class GroupsRepositoryCareTaker : IStudentRepository
{
    private GroupsRepository GroupsRepository = new GroupsRepository();
    private List<IMomento> History = new List<IMomento>();

    public void RemoveStudent(int groupId, Student student) 
    {
        History.Add(GroupsRepository.Save());
        GroupsRepository.RemoveStudent(groupId, student); 
    }
    public void AddStudent(int groupId, Student student) 
    {
        History.Add(GroupsRepository.Save());
        GroupsRepository.AddStudent(groupId, student); 
    }

    public void Undo()
    {
        if (History.Count == 0)
            return;
        GroupsRepository.Restore(History.Last());
        History.RemoveAt(History.Count - 1);
    }
    public Student GetStudent(int groupId, int studentId) => GroupsRepository.GetStudent(groupId, studentId);

    public string RepositoryToString() => GroupsRepository.ToString();

    public override string ToString()
    {
        return $"Количество состояний: {History.Count}\n\r{GroupsRepository}";
    }
}

public class GroupsRepository
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

    public IMomento Save()
    {
        return new GroupsRepositoryMomento(Groups);
    }

    public void Restore(IMomento momento)
    {
        if (!(momento is GroupsRepositoryMomento))
            throw new ArgumentException("Uncorrect IMomento");

        Groups = new List<Group>(((GroupsRepositoryMomento)momento).Groups.Select(s => s.Copy()));
    }

    class GroupsRepositoryMomento : IMomento
    {
        public readonly List<Group> Groups;
        public GroupsRepositoryMomento(List<Group> groups)
        {
            Groups = new List<Group>(groups.Select(g => g.Copy()));
        }
    }

    class Group
    {
        public string Name { get; set; }
        public List<Student> Students = new List<Student>();
        public override string ToString()
        {
            return $"{Name}{(Students.Count > 0 ? $":\n\r\t{String.Join("\n\r\t", Enumerable.Range(1, Students.Count).Zip(Students, (number, student) => $"{number}. {student}"))}" : String.Empty)}";
        }
        public Group Copy()
        {
            return new Group()
            {
                Name = Name,
                Students = new List<Student>(Students.Select(s => s.Copy()))
            };
        }
    }
}


public class AddStudentCommand : ICommand
{
    IStudentRepository GroupRepository;
    public AddStudentCommand(IStudentRepository groupRepository)
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

        Console.WriteLine(GroupRepository.RepositoryToString());
        Console.WriteLine("Введите номер группы в которую необходимо добавить студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.AddStudent(groupId, new Student(lastName, firstName, patronomyc));
    }
}

public class RemoveStudentCommand : ICommand
{
    IStudentRepository GroupRepository;
    public RemoveStudentCommand(IStudentRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository.RepositoryToString());
        Console.WriteLine("Введите номер группы в которой необходимо удалить студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите номер студента, которого необходимо удалить.");
        var studentId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.RemoveStudent(groupId, GroupRepository.GetStudent(groupId, studentId));
    }
}

public class CutStudentCommand : ICommand
{
    IStudentRepository GroupRepository;
    public CutStudentCommand(IStudentRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository.RepositoryToString());
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
    IStudentRepository GroupRepository;
    public CopyStudentCommand(IStudentRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository.RepositoryToString());
        Console.WriteLine("Введите номер группы из которой необходмо скопировать студента.");
        var groupId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите номер студента, которого необходимо скопировать.");
        var studentId = Convert.ToInt32(Console.ReadLine());

        var copiedStudent = GroupRepository.GetStudent(groupId, studentId).Copy();

        Console.WriteLine("Введите номер группы в которую необходмо скопировать студента.");
        var newGroupId = Convert.ToInt32(Console.ReadLine());

        GroupRepository.AddStudent(newGroupId, copiedStudent);
    }
}

public class ShowRepositoryCommand : ICommand
{
    IStudentRepository GroupRepository;
    public ShowRepositoryCommand(IStudentRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        Console.WriteLine(GroupRepository);
    }
}

public class UndoCommand : ICommand
{
    IStudentRepository GroupRepository;
    public UndoCommand(IStudentRepository groupRepository)
    {
        GroupRepository = groupRepository;
    }

    public void Execute()
    {
        GroupRepository.Undo();
    }
}

public class ConsoleReader
{
    ICommand AddCommand;
    ICommand RemoveCommand;
    ICommand CutCommand;
    ICommand CopyCommand;
    ICommand ShowCommand;
    ICommand UndoCommand;

    public ConsoleReader(ICommand AddCommand, ICommand RemoveCommand, ICommand CutCommand, ICommand CopyCommand, ICommand ShowCommand, ICommand UndoCommand)
    {
        this.AddCommand = AddCommand;
        this.RemoveCommand = RemoveCommand;
        this.CutCommand = CutCommand;
        this.CopyCommand = CopyCommand;
        this.ShowCommand = ShowCommand;
        this.UndoCommand = UndoCommand;
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
                    case "u":
                        UndoCommand.Execute();
                        break;
                    case "exit":
                        return;
                    default:
                        {
                            Console.WriteLine(
                                   $"Управление студентами\n\r" +
                                   $"\tДобавить студента               E\n\r" +
                                   $"\tУдалить студента                D\n\r" +
                                   $"\tСкопировать студента            C\n\r" +
                                   $"\tПереместить студента            X\n\r" +
                                   $"\tОтменить последнее действие     U\n\r" +

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
        var repo = new GroupsRepositoryCareTaker();

        var reader = new ConsoleReader(
            new AddStudentCommand(repo),
            new RemoveStudentCommand(repo),
            new CutStudentCommand(repo),
            new CopyStudentCommand(repo),
            new ShowRepositoryCommand(repo),
            new UndoCommand(repo));

        reader.Run();
    }
}