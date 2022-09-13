using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Delegate_Types
{
    class Program
    {
        public delegate bool Filter<in T>(T element);
        static void Main(string[] args)
        {
            Console.Title = "AzZazi!";
            Console.ForegroundColor = ConsoleColor.Green;
            //////////////////////////////////////////////////

            IEnumerable<int> Elements = new int[] { 5, 7, 9, 3, 2, 1, 8 };
                                                                                          //delegate directly هينطبق ع الـ  IEnumerable<> انت كدا لما تيجي تحدد نوع الـ 
            PrintNums(Elements, (element) => element <= 6, () => Console.WriteLine("Nums Less Than 6."));
                                                                                         /*element بقت int علشان ال IEnumerable بقت int*/
            Console.WriteLine("=========================");

            PrintNums(Elements, (element) => element % 2 == 0, () => Console.WriteLine("Even Nums."));

            Console.WriteLine("=========================");

            PrintNums(Elements, (element) => element % 2 != 0, () => Console.WriteLine("Single Nums."));

            Console.WriteLine("=========================");
                                                                                        //=============================================================
            IEnumerable<double> Elements2 = new double[] { 5.33, 7.25, 9.8, 3.94, 2.25, 1.84, 8.15 };

            PrintNums(Elements2, (element) => element <= 7.25, () => Console.WriteLine("Nums Less Than or Equal 7.25"));
                                                                                       /*element بقت double علشان ال IEnumerable بقت double*/

            Console.ReadKey();
        }

        public static void PrintNums<T>(IEnumerable<T> elements, /*Predicate<T> filter*/ Filter<T> filter /*Func<T,bool> filter*/, Action Act)
        {
            Act();
            foreach (var _element in elements)
            {
                if (filter(_element)) { Console.WriteLine(_element); }
            }
        }
    }
}
