using System;
using System.Collections.Generic;
using System.Linq;

namespace pat2
{
    public class TIntSet
    {
        private int[] Array { get; }
        public int Capacity
        {
            get
            {
                return Array.Length;
            }
        }
        public TIntSet(int capacity)
        {
            Array = new int[capacity];
        }
        public TIntSet(TIntSet intSet)
        {
            var temp = new int[intSet.Capacity];
            System.Array.Copy(intSet.Array, temp, intSet.Capacity);
            Array = temp;
        }
        public TIntSet(List<int> intList)
        {
            var temp = new int[intList.Count];
            System.Array.Copy(intList.ToArray(), temp, intList.Count);
            Array = temp;
        }
        public TIntSet(int capacity, int maxValue, int minValue = 0)
        {
            var rnd = new Random();
            Array = new int[capacity];

            for (int i = 0; i < capacity; i++)
                this.Array[i] = rnd.Next(minValue, maxValue);
        }
        public void Set(int position, int value)
        {
            Array[position] = value;
        }
        public bool isEqual(TIntSet b)
        {
            return Array.SequenceEqual(b.Array);
        }
        public override string ToString()
        {
            return "TIntSet: " + string.Join(", ", Array);
        }
        public static TIntSet Union(TIntSet a, TIntSet b)
        {
            var temp = new TIntSet(a.Capacity + b.Capacity);

            System.Array.Copy(a.Array, temp.Array, a.Capacity);
            System.Array.Copy(b.Array, 0, temp.Array, a.Capacity, b.Capacity);

            return temp;
        }
        public static bool isEqual(TIntSet a, TIntSet b)
        {
            return a.isEqual(b);
        }
    }
    class Program
    {
        public static Dictionary<string, TIntSet> IntSetDictionary = new Dictionary<string, TIntSet>();
        static void Main(string[] args)
        {
            ConsoleReader();
        }
        public static void ConsoleReader()
        {
            string input = "";
            while (input != "exit")
            {
                HandleCommand(input);
                input = Console.ReadLine();
            }
            void HandleCommand(string command)
            {
                var args = command.Split(' ');
                var cmd = args[0].ToLower();
                try
                {
                    switch (cmd)
                    {
                        case "crt":
                            {
                                switch (args[1])
                                {
                                    case "-z":
                                        IntSetDictionary.Add(args[2], new TIntSet(Convert.ToInt32(args[3])));
                                        break;
                                    case "-arr":
                                        Console.WriteLine("Введите числа через Enter, exit - для выхода");
                                        var temp = new List<int>();
                                        var inp = Console.ReadLine();
                                        while (inp != "exit")
                                        {
                                            temp.Add(Convert.ToInt32(inp));
                                            inp = Console.ReadLine();
                                        }
                                        IntSetDictionary.Add(args[2], new TIntSet(temp));
                                        break;
                                    case "-rnd":
                                        IntSetDictionary.Add(args[2], new TIntSet(Convert.ToInt32(args[3]), 100));
                                        break;
                                    case "-copy":
                                        IntSetDictionary.Add(args[2], new TIntSet(IntSetDictionary[args[3]]));
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                        case "sh":
                            {
                                Console.WriteLine(IntSetDictionary[args[1]]);
                                break;
                            }
                        case "un":
                            {
                                IntSetDictionary.Add(args[1], TIntSet.Union(IntSetDictionary[args[2]], IntSetDictionary[args[3]]));
                                break;
                            }
                        case "eq":
                            {
                                Console.WriteLine(TIntSet.isEqual(IntSetDictionary[args[1]], IntSetDictionary[args[2]]));
                                break;
                            }
                        case "set":
                            {
                                IntSetDictionary[args[1]].Set(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]));
                                break;
                            }
                        default:
                            {
                                Console.WriteLine($"<author> - Значение, \"author\" - Параметр \n\r\n\r" +
                                  $"Создать пустое множество              crt -z <название объекта> <количество элементов в объекте> \n\r" +
                                  $"Создать множество с задаными числами  crt -arr <название объекта> ...\n\r" +
                                  $"Создать множество случаных чисел      crt -rnd <название объекта> <количество элементов в объекте> \n\r" +
                                  $"Создать копию множества               crt -copy <название нового объекта> <название копируемого объекта> \n\r" +
                                  $"Объединение двух множеств             un <название новго объекта> <название объекта 1> <название объекта 2>\n\r" +
                                  $"Проверка равенства двух множеств      eq <название объекта> <название объекта>\n\r" +
                                  $"Замена элемента множества             set <название объекта> <номер> <значение>\n\r" +
                                  $"Вывод множества                       sh <название объекта>\n\r" +
                                  $"Выход                                 exit\n\r");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}