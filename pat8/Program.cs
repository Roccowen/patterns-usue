public class Document
{
    internal string name;
    public string GetName() => name;

    internal string description;
    public string GetDescription() => description;

    internal string creatorPosition;
    public string GetCreatorPosition() => creatorPosition;

    internal string creatorFullName;
    public string GetCreatorFullName() => creatorFullName;

    internal DateTime creationDate;
    public string GetCreationDate() => creationDate.ToShortDateString();

    public override string ToString() => $"\t{GetName()}\n\r{GetDescription()}\n\r\n\r{GetCreationDate()} {GetCreatorPosition()} {GetCreatorFullName()}";
}
public class RussianDocument : Document
{
    public new string GetCreationDate() => creationDate.ToString("dd.MM.yyyy");
    public override string ToString() => $"Русский документ: {base.ToString()}";
}
public class EnglishDocument : Document
{
    public new string GetCreationDate() => creationDate.ToString("MM-dd-yyyy");
    public override string ToString() => $"Английский документ: {base.ToString()}";
}
public class EnglishDocumentAdapter : RussianDocument
{
    private EnglishDocument document;
    public new string GetName() => document.GetName();
    public new string GetDescription() => document.GetDescription();
    public new string GetCreatorPosition() => document.GetCreatorPosition();
    public new string GetCreatorFullName() => document.GetCreatorFullName();
    public new string GetCreationDate() => document.GetCreationDate();
}
public static class Programm
{
    static void Main(string[] args) => ConsoleReader();
    public static Dictionary<string, Document> Documents = new Dictionary<string, Document>();
    public static Dictionary<int, string> Positions = new Dictionary<int, string>()
    {
        {1, "Начальник" },
        {2, "Преподаватель" },
    };
    public static Dictionary<int, (Type type, string name)> DocumentTypes = new Dictionary<int, (Type type, string name)>()
    {
        {1, (typeof(RussianDocument), "Русский документ") },
        {2, (typeof(EnglishDocument), "Английский документ") },
    };

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
                        Console.WriteLine($"Введите идентификатор документа: " +
                            $"\n\r\t{DocumentTypes.Keys.Select(k => $"{k} - ").Zip(DocumentTypes.Values.Select(v => v.name))}\n\r");
                        var documentType = DocumentTypes[Convert.ToInt32(Console.ReadLine())].type;
                        
                        Console.WriteLine($"Введите идентификатор должности составителя: " +
                            $"\n\r\t{Positions.Keys.Select(k => $"{k} - ").Zip(Positions.Values)}\n\r");
                        var creatorPosition = Positions[Convert.ToInt32(Console.ReadLine())];
                        
                        Console.WriteLine("Введите ФИО составителя:");
                        var creatorName = Console.ReadLine();

                        Console.WriteLine("Введите дату составления:");
                        var creationDate = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("Введите текст документа:");
                        var description = Console.ReadLine();

                        Console.WriteLine("Введите название документа:");
                        var name = Console.ReadLine();

                        Documents.Add(name, documentType.)
                        break;
                    case "2":
                        Console.WriteLine("Введите дату начала учебы группы (дд.мм.гггг):");
                        CurrentStudentGroup.Admission = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case "exit":
                        return;
                    default:
                        {
                            Console.WriteLine(
                                   $"Управление документами \n\r" +
                                   $"\tДобавить документ         1\n\r" +
                                   $"\tУдалить документ          2\n\r\n\r" +
                                   $"Выход                       exit\n\r");
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