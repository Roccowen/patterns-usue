using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pat3
{
    public class TIntSetBuilder
    {
        public TIntSetBuilder()
        {

        }
    }
    public interface ITIntVarSetBuilder
    {
        ConcreteTIntVarSet CreateIntSet(List<int> numbersRange);
        ConcreteTIntVarSet CreateIntSet(int capacity);
        ConcreteTIntVarSet CreateIntSet(int capacity, int param);
    }
    public interface ITIntSetUnionionable
    {
        ConcreteTIntVarSet OrderedUnionWith(ConcreteTIntVarSet intSet1);
        ConcreteTIntVarSet LogicalUnionWith(ConcreteTIntVarSet intSet1);
        ConcreteTIntVarSet UnionWith(ConcreteTIntVarSet intSet1);
    }
    public class TIntSet
    {
        private int[] Array { get; }
        public IEnumerable<int> Numbers
        {
            get
            {
                foreach (var n in Array)
                    yield return n;
            }
        }
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
        public virtual void Set(int position, int value)
        {
            Array[position] = value;
        }
        public bool isEqual(TIntSet b)
        {
            return Array.SequenceEqual(b.Array);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: " + string.Join(", ", Array);
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
    public class TIntMixedSetBuilder : TIntSetBuilder, ITIntVarSetBuilder
    {
        public TIntMixedSetBuilder()
        {

        }

        public ConcreteTIntVarSet CreateIntSet(int capacity)
        {
            return new TIntMixedSet(capacity);
        }

        public ConcreteTIntVarSet CreateIntSet(int capacity, int param)
        {
            return new TIntMixedSet(capacity);
        }

        public ConcreteTIntVarSet CreateIntSet(List<int> numbersRange)
        {
            return new TIntMixedSet(numbersRange);
        }
    }
    public class TIntPositiveSetBuilder : TIntSetBuilder, ITIntVarSetBuilder
    {
        public TIntPositiveSetBuilder()
        {

        }

        public ConcreteTIntVarSet CreateIntSet(int capacity)
        {
            return new TIntPositiveSet(capacity);
        }

        public ConcreteTIntVarSet CreateIntSet(int capacity, int max)
        {
            return new TIntPositiveSet(capacity, max);
        }

        public ConcreteTIntVarSet CreateIntSet(List<int> numbersRange)
        {
            return new TIntPositiveSet(numbersRange);
        }
    }
    public class TIntNegativeSetBuilder : TIntSetBuilder, ITIntVarSetBuilder
    {
        public TIntNegativeSetBuilder()
        {

        }
        public ConcreteTIntVarSet CreateIntSet(int capacity)
        {
            return new TIntNegativeSet(capacity);
        }

        public ConcreteTIntVarSet CreateIntSet(int capacity, int min)
        {
            return new TIntNegativeSet(capacity, min);
        }

        public ConcreteTIntVarSet CreateIntSet(List<int> numbersRange)
        {
            return new TIntNegativeSet(numbersRange);
        }
    }
    public class TIntZerosSetBuilder : TIntSetBuilder, ITIntVarSetBuilder
    {
        public TIntZerosSetBuilder()
        {

        }
        public ConcreteTIntVarSet CreateIntSet(int capacity)
        {
            return new TIntZerosSet(capacity);
        }

        public ConcreteTIntVarSet CreateIntSet(int capacity, int param)
        {
            return new TIntZerosSet(capacity);
        }

        public ConcreteTIntVarSet CreateIntSet(List<int> numbersRange)
        {
            return new TIntZerosSet(numbersRange);
        }

        public ConcreteTIntVarSet CreateIntSet(List<int> numbersRange, int param)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class ConcreteTIntVarSet : TIntSet, ITIntSetUnionionable
    {
        public ConcreteTIntVarSet(int capacity) : base(capacity)
        {

        }
        public ConcreteTIntVarSet(int capacity, int maxValue, int minValue) : base(capacity, maxValue, minValue)
        {

        }
        public ConcreteTIntVarSet(List<int> intList) : base(intList)
        {

        }
        public abstract ConcreteTIntVarSet LogicalUnionWith(ConcreteTIntVarSet intSet1);
        public abstract ConcreteTIntVarSet OrderedUnionWith(ConcreteTIntVarSet intSet1);
        public abstract ConcreteTIntVarSet UnionWith(ConcreteTIntVarSet intSet1);
    }
    public class TIntMixedSet : ConcreteTIntVarSet
    {
        public TIntMixedSet(int capacity) : base(capacity, 100, -100)
        {

        }
        public TIntMixedSet(List<int> positiveIntList) : base(positiveIntList)
        {

        }
        public override ConcreteTIntVarSet OrderedUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers);
            temp.AddRange(intSet1.Numbers);
            temp = temp.OrderBy(n => n).ToList();

            return new TIntMixedSet(temp);
        }
        public override ConcreteTIntVarSet LogicalUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.ToHashSet());
            temp.AddRange(intSet1.Numbers.ToHashSet());

            return new TIntMixedSet(temp);
        }
        public override ConcreteTIntVarSet UnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers);
            temp.AddRange(intSet1.Numbers);

            return new TIntMixedSet(temp);
        }
    }
    public class TIntPositiveSet : ConcreteTIntVarSet
    {
        public TIntPositiveSet(int capacity, int maxValue = 100) : base(capacity, maxValue, 1)
        {

        }
        public TIntPositiveSet(List<int> positiveIntList) : base(positiveIntList)
        {

        }
        public override void Set(int position, int value)
        {
            if (value > 0)
                base.Set(position, value);
            else
                throw new ArgumentException("value должно быть положительным");
        }
        public override ConcreteTIntVarSet OrderedUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n > 0));
            temp.AddRange(intSet1.Numbers.Where(n => n > 0));
            temp = temp.OrderBy(n => n).ToList();

            return new TIntPositiveSet(temp);
        }
        public override ConcreteTIntVarSet LogicalUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n > 0).ToHashSet());
            temp.AddRange(intSet1.Numbers.Where(n => n > 0).ToHashSet());

            return new TIntPositiveSet(temp);
        }
        public override ConcreteTIntVarSet UnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n > 0));
            temp.AddRange(intSet1.Numbers.Where(n => n > 0));

            return new TIntPositiveSet(temp);
        }
    }
    public class TIntNegativeSet : ConcreteTIntVarSet
    {
        public TIntNegativeSet(int capacity, int minValue = -100) : base(capacity, -1, minValue)
        {

        }
        public TIntNegativeSet(List<int> negativeIntList) : base(negativeIntList)
        {

        }
        public override void Set(int position, int value)
        {
            if (value < 0)
                base.Set(position, value);
            else
                throw new ArgumentException("value должно быть отрицательным");
        }
        public override ConcreteTIntVarSet OrderedUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n < 0));
            temp.AddRange(intSet1.Numbers.Where(n => n < 0));
            temp = temp.OrderBy(n => n).ToList();

            return new TIntNegativeSet(temp);
        }
        public override ConcreteTIntVarSet LogicalUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n < 0).ToHashSet());
            temp.AddRange(intSet1.Numbers.Where(n => n < 0).ToHashSet());

            return new TIntNegativeSet(temp);
        }
        public override ConcreteTIntVarSet UnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n < 0));
            temp.AddRange(intSet1.Numbers.Where(n => n < 0));

            return new TIntNegativeSet(temp);
        }
    }
    public class TIntZerosSet : ConcreteTIntVarSet
    {
        public TIntZerosSet(int capacity) : base(capacity)
        {

        }
        public TIntZerosSet(List<int> zerosIntList) : base(zerosIntList)
        {

        }
        public override void Set(int position, int value)
        {
            if (value == 0)
                base.Set(position, value);
            else
                throw new ArgumentException("value должно быть нулём");
        }
        public override ConcreteTIntVarSet OrderedUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n == 0));
            temp.AddRange(intSet1.Numbers.Where(n => n == 0));
            temp = temp.OrderBy(n => n).ToList();

            return new TIntZerosSet(temp);
        }
        public override ConcreteTIntVarSet LogicalUnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n == 0).ToHashSet());
            temp.AddRange(intSet1.Numbers.Where(n => n == 0).ToHashSet());

            return new TIntZerosSet(temp);
        }
        public override ConcreteTIntVarSet UnionWith(ConcreteTIntVarSet intSet1)
        {
            var temp = new List<int>(base.Capacity + intSet1.Capacity);

            temp.AddRange(base.Numbers.Where(n => n == 0));
            temp.AddRange(intSet1.Numbers.Where(n => n == 0));

            return new TIntZerosSet(temp);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader();
        }
        public static TIntMixedSetBuilder MixedIntSetBuilder = new TIntMixedSetBuilder();
        public static TIntPositiveSetBuilder PositiveIntSetBuilder = new TIntPositiveSetBuilder();
        public static TIntNegativeSetBuilder NegativeIntSetBuilder = new TIntNegativeSetBuilder();
        public static TIntZerosSetBuilder ZerosIntSetBuilder = new TIntZerosSetBuilder();
        public static Dictionary<string, ConcreteTIntVarSet> IntSetStorage = new Dictionary<string, ConcreteTIntVarSet>();
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
                var args = command.Split(' ');
                try
                {
                    switch (args[0].ToLower())
                    {
                        case "crt":
                            {
                                switch (args[1].ToLower())
                                {
                                    case "-pos":
                                        IntSetStorage.Add(args[2], PositiveIntSetBuilder.CreateIntSet(Convert.ToInt32(args[3])));
                                        break;
                                    case "-neg":
                                        IntSetStorage.Add(args[2], NegativeIntSetBuilder.CreateIntSet(Convert.ToInt32(args[3])));
                                        break;
                                    case "-zer":
                                        IntSetStorage.Add(args[2], ZerosIntSetBuilder.CreateIntSet(Convert.ToInt32(args[3])));
                                        break;
                                    default:
                                        Console.WriteLine("Введите числа через Enter, exit - для выхода");
                                        var temp = new List<int>();
                                        var inp = Console.ReadLine();
                                        while (inp != "exit")
                                        {
                                            temp.Add(Convert.ToInt32(inp));
                                            inp = Console.ReadLine();
                                        }

                                        if (temp.All(n => n > 0))
                                        {
                                            IntSetStorage.Add(args[1], PositiveIntSetBuilder.CreateIntSet(temp));
                                            break;
                                        }
                                        if (temp.All(n => n < 0))
                                        {
                                            IntSetStorage.Add(args[1], NegativeIntSetBuilder.CreateIntSet(temp));
                                            break;
                                        }
                                        if (temp.All(n => n == 0))
                                        {
                                            IntSetStorage.Add(args[1], ZerosIntSetBuilder.CreateIntSet(temp));
                                            break;
                                        }
                                        IntSetStorage.Add(args[1], MixedIntSetBuilder.CreateIntSet(temp));
                                        break;
                                }
                                break;
                            }
                        case "sh":
                            {
                                Console.WriteLine(IntSetStorage[args[1]]);
                                break;
                            }
                        case "un":
                            {
                                switch (args[1])
                                {
                                    case "-ord":
                                        {
                                            IntSetStorage.Add(args[2], IntSetStorage[args[3]].OrderedUnionWith(IntSetStorage[args[4]]));
                                            break;
                                        }
                                    case "-log":
                                        {
                                            IntSetStorage.Add(args[2], IntSetStorage[args[3]].LogicalUnionWith(IntSetStorage[args[4]]));
                                            break;
                                        }
                                    case "-def":
                                        {
                                            IntSetStorage.Add(args[2], IntSetStorage[args[3]].UnionWith(IntSetStorage[args[4]]));
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                break;
                            }
                        case "eq":
                            {
                                Console.WriteLine(TIntSet.isEqual(IntSetStorage[args[1]], IntSetStorage[args[2]]));
                                break;
                            }
                        case "set":
                            {
                                IntSetStorage[args[1]].Set(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]));
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(
                                  $"Создать множество по входному массиву чисел            crt <название объекта> ...\n\r" +
                                  $"Упорядоченное объединение первого множества со вторым  un -ord <название новго объекта> <название объекта 1> <название объекта 2>\n\r" +
                                  $"Логическое объединение первого множества со вторым     un -log <название новго объекта> <название объекта 1> <название объекта 2>\n\r" +
                                  $"Объединение первого множества со вторым                un -def <название новго объекта> <название объекта 1> <название объекта 2>\n\r" +
                                  $"Проверка равенства двух множеств                       eq <название объекта> <название объекта>\n\r" +
                                  $"Вывод множества                                        sh <название объекта>\n\r" +
                                  $"Выход                                                  exit\n\r");
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