// See https://aka.ms/new-console-template for more information
using System.Threading;


for (int i = 0; i < 100; i++)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Thread.Sleep(500);
    Console.WriteLine("Lightning McQueen");
}