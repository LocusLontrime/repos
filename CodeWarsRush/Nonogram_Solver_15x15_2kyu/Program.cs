using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NonogramInversor
{
    class Nonogram
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int[][] columnRules;
        private readonly int[][] rowRules;

        public Nonogram(int[][] columnRules, int[][] rowRules)
        {
            this.columns = columnRules.Length;
            this.rows = rowRules.Length;
            this.columnRules = columnRules;
            this.rowRules = rowRules;
        }

        private List<Line> Generate(int[] rules, int length)
        {
            var result = new List<(int offset, Line line)>();

            var remainingSums = new int[rules.Length];
            for (var sumIndex = 1; sumIndex < remainingSums.Length; sumIndex++)
                remainingSums[sumIndex] = rules[sumIndex - 1] + 1 + remainingSums[sumIndex - 1];

            var initial = new Line();
            for (var i = 0; i < rules.Length; i++)
                initial = initial.SetAt(remainingSums[i], rules[i]);

            result.Add((0, initial));

            var max = 1u << length;

            for (var ruleIndex = 0; ruleIndex < rules.Length; ruleIndex++)
            {
                var remainingSum = remainingSums[ruleIndex];

                var window = result.Count;
                for (var index = 0; index < window; index++)
                {
                    var (offset, current) = result[index];

                    for (var shift = 0; ; shift++)
                    {
                        current = current.ShiftLeftAt(remainingSum + offset + shift);
                        if (current.Bits >= max)
                            break;

                        result.Add((offset + shift + 1, current));
                    }
                }
            }

            return result.Select(x => x.line).ToList();
        }

        private void Reduce(List<List<Line>> rows, List<List<Line>> columns)
        {
            var allSet = (1u << this.columns) - 1;

            int count;
            do
            {
                count = 0;

                for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                {
                    var row = rows[rowIndex];
                    var alwaysSet = row.Aggregate((a, b) => a & b);
                    var alwaysUnset = row.Aggregate((a, b) => a | b);
                    if (alwaysSet.Bits == 0 && alwaysUnset.Bits == allSet)
                        continue;

                    for (var columnIndex = 0; columnIndex < columns.Count; columnIndex++)
                    {
                        var column = columns[columnIndex];

                        if (alwaysSet.Get(columnIndex))
                            count += column.RemoveAll(c => !c.Get(rowIndex));

                        if (!alwaysUnset.Get(columnIndex))
                            count += column.RemoveAll(c => c.Get(rowIndex));
                    }
                }

                for (var columnIndex = 0; columnIndex < columns.Count; columnIndex++)
                {
                    var column = columns[columnIndex];
                    var alwaysSet = column.Aggregate((a, b) => a & b);
                    var alwaysUnset = column.Aggregate((a, b) => a | b);
                    if (alwaysSet.Bits == 0 && alwaysUnset.Bits == allSet)
                        continue;

                    for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                    {
                        var row = rows[rowIndex];

                        if (alwaysSet.Get(rowIndex))
                            count += row.RemoveAll(r => !r.Get(columnIndex));

                        if (!alwaysUnset.Get(rowIndex))
                            count += row.RemoveAll(r => r.Get(columnIndex));
                    }
                }
            } while (count > 0);
        }

        public int[][] Solve()
        {
            var rows = rowRules.Select(x => Generate(x, this.columns)).ToList();
            var columns = columnRules.Select(x => Generate(x, this.rows)).ToList();
            Reduce(rows, columns);

            //Print(rows.SelectMany(x => x).ToList());

            return CalculateSolution(rows.SelectMany(x => x).ToList(), columns.SelectMany(x => x).ToList());
        }

        private int[][] CalculateSolution(List<Line> rows, List<Line> columns)
        {
            var results = new int[columnRules.Length + rowRules.Length][];

            var rowSelector = (1u << columns.Count) - 1;
            var columnSelector = (1u << rows.Count) - 1;

            for (var columnIndex = 0; columnIndex < columns.Count; columnIndex++)
            {
                var column = columns[columnIndex];

                var rules = new List<int> { 0 };
                var index = 0;

                var prev = 0u;

                for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                {
                    var flag = 1u << rowIndex;
                    var cell = ((~column.Bits) & columnSelector) & flag;
                    if (cell == flag)
                    {
                        if (rules.Count == index)
                            rules.Add(1);
                        else
                            rules[index]++;
                    }
                    else if (prev != 0)
                    {
                        index++;
                    }

                    prev = cell;
                }

                results[columnIndex] = rules.ToArray();
            }

            for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                var row = rows[rowIndex];

                var rules = new List<int> { 0 };
                var index = 0;

                var prev = 0u;

                for (var columnIndex = 0; columnIndex < columnRules.Length; columnIndex++)
                {
                    var flag = 1u << columnIndex;
                    var cell = ((~row.Bits) & rowSelector) & flag;
                    if (cell == flag)
                    {
                        if (rules.Count == index)
                            rules.Add(1);
                        else
                            rules[index]++;
                    }
                    else if (prev != 0)
                    {
                        index++;
                    }

                    prev = cell;
                }

                results[columnRules.Length + rowIndex] = rules.ToArray();
            }

            return results;
        }

        private void Print(List<Line> array)
        {
            for (var rowIndex = 0; rowIndex < array.Count; rowIndex++)
            {
                var row = array[rowIndex];

                for (var columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    var flag = 1 << columnIndex;
                    if ((row.Bits & flag) == flag)
                        Console.Write(" \x25A0 |");
                    else
                        Console.Write("   |");
                }

                Console.WriteLine();
            }
        }
    }

    public readonly struct Line
    {
        public Line(uint bits) => Bits = bits;

        public static Line operator &(Line left, Line right)
            => new Line(left.Bits & right.Bits);
        public static Line operator |(Line left, Line right)
            => new Line(left.Bits | right.Bits);

        public override string ToString()
            => Convert.ToString(Bits, 2);

        public bool Get(int index)
            => (Bits & (1u << index)) != 0;
        public Line Set(int index)
            => new Line(Bits | (1u << index));
        public Line SetAt(int start, int value)
            => new Line(Bits | ((1u << (start + value)) - 1 - ((1u << start) - 1)));
        public Line ShiftLeftAt(int index)
            => new Line((Bits >> index << (index + 1)) | (Bits & ((1u << index) - 1)));

        public uint Bits { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // var inputs = Console.ReadLine().Split(' ');
            // var width = int.Parse(inputs[0]);
            // var height = int.Parse(inputs[1]);

            // var columns = new int[width][];
            // for (int i = 0; i < width; i++)
            //     columns[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // var rows = new int[height][];
            // for (int i = 0; i < height; i++)
            //     rows[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // var game = new Nonogram(columns, rows);
            // game.Solve();
            // game.Inverse();
            // var solution = game.CalculateSolution();

            // foreach (var row in solution)
            //     Console.WriteLine(string.Join(" ", row));

            Test0();
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
        }

        static void Test(int[][] columns, int[][] rows)
        {
            var sw = Stopwatch.StartNew();

            var game = new Nonogram(columns, rows);
            Console.WriteLine("Original:");
            var solution = game.Solve();

            sw.Stop();

            foreach (var row in solution)
                Console.WriteLine(string.Join(" ", row));

            Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
        }

        static void Test0()
        {
            var columns = new int[][]
            {
                new [] { 1, 1 },
                new [] { 2 },
                new [] { 3 },
                new [] { 4 },
            };

            var rows = new int[][]
            {
                new [] { 4 },
                new [] { 3 },
                new [] { 2 },
                new [] { 1, 1 },
            };

            Test(columns, rows);
        }

        static void Test1()
        {
            var columns = new int[][]
            {
                new [] { 1 },
                new [] { 3 },
                new [] { 2 },
                new [] { 5 },
                new [] { 1 },
            };

            var rows = new int[][]
            {
                new [] { 1 },
                new [] { 1, 3 },
                new [] { 3 },
                new [] { 1, 1 },
                new [] { 1, 1 },
            };

            Test(columns, rows);
        }

        static void Test2()
        {
            var columns = new int[][]
            {
                new [] { 2 },
                new [] { 4 },
                new [] { 4 },
                new [] { 8 },
                new [] { 1, 1 },
                new [] { 1, 1 },
                new [] { 1, 1, 2 },
                new [] { 1, 1, 4 },
                new [] { 1, 1, 4 },
                new [] { 8 },
            };

            var rows = new int[][]
            {
                new [] { 4 },
                new [] { 3, 1 },
                new [] { 1, 3 },
                new [] { 4, 1 },
                new [] { 1, 1 },
                new [] { 1, 3 },
                new [] { 3, 4 },
                new [] { 4, 4 },
                new [] { 4, 2 },
                new [] { 2 },
            };

            Test(columns, rows);
        }

        static void Test3()
        {
            var columns = new int[][]
            {
                new int[] { 3 },
                new int[] { 4 },
                new int[] { 1, 4, 3 },
                new int[] { 1, 4 },
                new int[] { 7, 5 },
                new int[] { 2, 4 },
                new int[] { 4, 4 },
                new int[] { 2, 6 },
                new int[] { 4 },
                new int[] { 1, 4, 3 },
                new int[] { 1, 4 },
                new int[] { 7, 2 },
                new int[] { 2, 4, 1 },
                new int[] { 4, 3, 1 },
                new int[] { 2, 7 },
            };

            var rows = new int[][]
            {
                new [] { 1, 1, 1, 1 },
                new [] { 1, 3, 1, 3 },
                new [] { 5, 5 },
                new [] { 1, 2, 1, 2 },
                new [] { 1, 1 },
                new [] { 2, 2 },
                new [] { 2, 2 },
                new [] { 2, 2 },
                new [] { 2, 2, 1 },
                new [] { 3, 4, 3 },
                new [] { 3, 6, 4 },
                new [] { 2, 5, 4 },
                new [] { 2, 6, 1, 1 },
                new [] { 1, 2, 1, 1, 1 },
                new [] { 1, 1, 1, 1, 3 },
            };

            Test(columns, rows);
        }

        static void Test4()
        {
            var columns = new int[][]
            {
                new int[] { 2, 6, 3 },
                new int[] { 4, 6, 1 },
                new int[] { 7, 1 },
                new int[] { 6, 9, 1 },
                new int[] { 6, 12 },
                new int[] { 2, 12, 2 },
                new int[] { 14, 1, 1 },
                new int[] { 4, 7, 2, 2 },
                new int[] { 3, 8, 3 },
                new int[] { 7, 6, 4 },
                new int[] { 3, 2, 4, 1, 2 },
                new int[] { 2, 3, 3, 1, 1 },
                new int[] { 1, 2, 3, 2, 2, 2 },
                new int[] { 1, 8, 1, 1, 3 },
                new int[] { 1, 2, 2, 2, 2 },
            };

            var rows = new int[][]
            {
                new int [] { 1, 1, 1, 1 },
                new int [] { 2, 2, 1, 1 },
                new int [] { 7, 2, 1 },
                new int [] { 8, 3 },
                new int [] { 2, 2, 2, 1 },
                new int [] { 1, 8, 1 },
                new int [] { 2, 3, 2, 3 },
                new int [] { 1, 4, 4 },
                new int [] { 1, 10 },
                new int [] { 2, 9, 1 },
                new int [] { 1, 8, 1 },
                new int [] { 1, 9 },
                new int [] { 11, 3 },
                new int [] { 8, 4, 1 },
                new int [] { 7, 2, 1 },
                new int [] { 7, 2, 1 },
                new int [] { 5, 4, 3 },
                new int [] { 2, 2, 1, 2, 1, 1 },
                new int [] { 1, 1, 2, 4, 2 },
                new int [] { 2, 5, 4 },
            };

            Test(columns, rows);
        }

        static void Test5()
        {
            var columns = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] { 3, 2 },
                new int[] { 1, 1, 1, 6 },
                new int[] { 3, 4 },
                new int[] { 3, 2 },
                new int[] { 3, 1, 2, 2 },
                new int[] { 1, 2, 1, 2, 3 },
                new int[] { 2, 3, 3, 4 },
                new int[] { 4, 2, 9 },
                new int[] { 7, 9 },
                new int[] { 4, 2, 9 },
                new int[] { 3, 1, 9 },
                new int[] { 3, 2, 8 },
                new int[] { 4, 5, 3 },
                new int[] { 10, 1 },
                new int[] { 10 },
                new int[] { 10 },
                new int[] { 9 },
                new int[] { 3 },
            };

            var rows = new int[][]
            {
                new int[] { 1, 6 },
                new int[] { 1, 8 },
                new int[] { 1, 10 },
                new int[] { 3, 3 },
                new int[] { 3, 1, 1, 1, 3 },
                new int[] { 15 },
                new int[] { 8, 5 },
                new int[] { 7 },
                new int[] { 1, 9 },
                new int[] { 12 },
                new int[] { 6, 4 },
                new int[] { 8, 3 },
                new int[] { 2, 7, 3 },
                new int[] { 2, 1, 6, 3 },
                new int[] { 4, 6, 2 },
                new int[] { 3, 6 },
                new int[] { 9 },
                new int[] { 7 },
                new int[] { 3 },
                new int[] { 4 },
            };

            Test(columns, rows);
        }
    }
}