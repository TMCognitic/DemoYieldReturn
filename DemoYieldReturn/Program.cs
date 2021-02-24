using System;
using System.Collections.Generic;

namespace DemoYieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>(new int[] { 0, 1, 2 });

            IEnumerable<int> pairs = Where(ints, delegate (int x) { return x % 2 == 0; });

            ints.Add(10);

            foreach (int item in pairs)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine();
            //ints.Add(3);
            //ints.Add(4);

            //foreach (int item in pairs)
            //{
            //    Console.WriteLine(item);
            //}

            foreach (string day in Where(GetDays(), delegate(string s) { return s.ToUpper().Contains("E"); }))
            {
                Console.WriteLine(day);
            }

            //using (IEnumerator<int> enumerator = pairs.GetEnumerator())
            //{
            //    while(enumerator.MoveNext())
            //    {
            //        int item = enumerator.Current;

            //        Console.WriteLine(item);
            //    }
            //}
        }

        static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        static IEnumerable<string> GetDays()
        {
            yield return "Lundi";
            yield return "Mardi";
            yield return "Mercredi";
            yield return "Jeudi";
            yield return "Vendredi";
            yield return "Samedi";
            yield return "Dimanche";
        }
    }
}
