using System;
using System.Threading;
using System.Text;

namespace AeroConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            Aero.MakeTransparent(191);
            Console.Title = "This is my world just believe me!";
            
            LockBitLog("Ready");
            Thread.Sleep(1000);
            LockBitLog("Steady");
            Thread.Sleep(1000);
            LockBitLog("GO!");

            Console.WriteLine("Press any key to continute...");
            Console.ReadKey();
        }

        private static void LockBitLog(string line)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(string.Format("[{0:D2}:{1:D2}:{2:D2}] ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
            
            Console.ResetColor();
        }
    }
}
