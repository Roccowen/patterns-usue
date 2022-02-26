public static class Programm
{
    interface ICommand
    {
        void Execute(object obj);
    }

    class AddStudentCommand : ICommand
    {
        public AddStudentCommand()
        {

        }

        public void Execute(object obj)
        {
            
        }
    }

    class RemoveStudentCommand : ICommand
    {
        public RemoveStudentCommand()
        {
                
        }

        public void Execute(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class CutStudentCommand : ICommand
    {
        public CutStudentCommand()
        {

        }

        public void Execute(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class CopyStudentCommand : ICommand
    {
        public CopyStudentCommand()
        {

        }

        public void Execute(object obj)
        {
            throw new NotImplementedException();
        }
    }
    
    class Group
    {
        public string Name { get; set; }
        public List<Student> Students = new List<Student>();
        public override string ToString() => $"{Name}:\n\r\t {String.Join("\n\r\t", Enumerable.Range(1, Students.Count).Zip(Students, (number, student) => $"{number}. {student}"))}";
    }

    class Student
    {
        public string Patronomyc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{LastName} {FirstName} {Patronomyc}";
    }

    static List<Group> Groups = new List<Group>()
    {
        new Group() { Name = "ЭМА-18-1" },
        new Group() { Name = "ЭМА-18-2" }
    };
    public static void Main(string[] args)
    {
        Groups[0].Students.Add(new Student()
        {
            FirstName = "Артме",
            LastName = "Мирвода",
            Patronomyc = "Валерьевич"
        });
        Groups[0].Students.Add(new Student()
        {
            FirstName = "Артме",
            LastName = "Мирвода",
            Patronomyc = "Валерьевич"
        });
        Groups[0].Students.Add(new Student()
        {
            FirstName = "Артме",
            LastName = "Мирвода",
            Patronomyc = "Валерьевич"
        });
        Groups[0].Students.Add(new Student()
        {
            FirstName = "Артме",
            LastName = "Мирвода",
            Patronomyc = "Валерьевич"
        });
        Console.WriteLine(Groups[0]);
    }
}