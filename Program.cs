using System;
using System.Linq;

namespace Parser_Logs
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Input path to File >> ");
            string pathToFile = Console.ReadLine();
            Console.Write("Input NickName >> ");
            string nickName = Console.ReadLine();

            var logs = Parser.Find(nickName, pathToFile);

            if (logs.Count() != 0)
            {
                foreach (var item in logs)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Nothing Found!");
            }
        }
    }
}
