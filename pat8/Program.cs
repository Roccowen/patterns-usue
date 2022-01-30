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

    public override string ToString() => $"\t{GetName()}\t\t\n\r{GetDescription()}\t\n\r\n\r{GetCreationDate()} {GetCreatorPosition()} {GetCreatorFullName()}";
}
public class RussianDocument : Document
{
    public new string GetCreationDate() => creationDate.ToString("dd.MM.yyyy");
    public override string ToString() => $"Русский документ:\n\r{base.ToString()}";
}
public class EnglishDocument : Document
{
    public new string GetCreationDate() => creationDate.ToString("MM-dd-yyyy");
    public override string ToString() => $"Английский документ:\n\r{base.ToString()}";
}
public class EnglishDocumentAdapter : RussianDocument
{
    public EnglishDocumentAdapter(EnglishDocument document) => this.document = document;
    private EnglishDocument document;
    public new string GetName() => document.GetName();
    public new string GetDescription() => document.GetDescription();
    public new string GetCreatorPosition() => document.GetCreatorPosition();
    public new string GetCreatorFullName() => document.GetCreatorFullName();
    public new string GetCreationDate() => document.GetCreationDate();
    public override string ToString() => $"Русский документ:\n\r\t{GetName()}\t\t\n\r{GetDescription()}\t\n\r\n\r{GetCreationDate()} {GetCreatorPosition()} {GetCreatorFullName()}";
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
                        Console.WriteLine("Введите текст документа:");
                        var description = Console.ReadLine();

                        Console.WriteLine("Введите название документа:");
                        var name = Console.ReadLine();

                        Console.WriteLine("Введите ФИО составителя:");
                        var creatorFullName = Console.ReadLine();

                        Console.WriteLine("Введите дату составления:");
                        var creationDate = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine($"Введите идентификатор должности составителя: " +
                            $"\n\r\t{String.Join("\n\r\t", Positions.Select(p => $"{p.Key} - {p.Value}"))}\n\r");
                        var creatorPosition = Positions[Convert.ToInt32(Console.ReadLine())];

                        Console.WriteLine($"Введите идентификатор документа: " +
                            $"\n\r\t1 - Русский документ" +
                            $"\n\r\t2 - Английский документ");
                        var documentType = Convert.ToInt32(Console.ReadLine());
                        if (documentType == 1)
                            Documents.Add(name, new RussianDocument()
                            {
                                name = name,
                                creationDate = creationDate,
                                description = description,
                                creatorPosition = creatorPosition,
                                creatorFullName = creatorFullName,
                            });
                        if (documentType == 2)
                            Documents.Add(name, new EnglishDocument()
                            {
                                name = name,
                                creationDate = creationDate,
                                description = description,
                                creatorPosition = creatorPosition,
                                creatorFullName = creatorFullName,
                            });
                        break;
                    case "2":
                        Console.WriteLine("Введите название документа которы необходимо удалить:");
                        Documents.Remove(Console.ReadLine());
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

                Console.WriteLine($"Имеющиеся документы: " +
                            $"\n\r{String.Join("\n\r", Documents.Select(n => n.Value.ToString()))}\n\r");
                Console.WriteLine($"Имеющиеся документы после адаптации:");
                Documents.ToList().ForEach(n => {
                    if (n.Value is EnglishDocument)
                        Console.WriteLine(new EnglishDocumentAdapter((EnglishDocument)n.Value));
                    else Console.WriteLine(n.Value);
                });
                    //Console.WriteLine($"Имеющиеся документы после адаптации: " +
                    //            $"\n\r{String.Join("\n\r", Documents.Select(n => { 
                    //                if (n.Value is EnglishDocument)
                    //                    return new EnglishDocumentAdapter((EnglishDocument)n.Value).ToString();
                    //                return n.Value.ToString();
                    //            }))}\n\r");

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