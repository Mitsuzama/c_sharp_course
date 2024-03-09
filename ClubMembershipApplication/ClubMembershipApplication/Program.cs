using System;

namespace ClubMembershipApplication
{
    class Program
    {
        // delegate
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Log log  = new Log();

            LogDel LogTextToScreenDel, LogTextToFileDel;
            
            LogTextToScreenDel = new LogDel(log.LogTextToScreen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;

            Console.WriteLine("Please enter name: ");

            var name = Console.ReadLine();
            
            LogText(multiLogDel, name);

            Console.ReadKey();
        }

        // passing a delegate as a parameter
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    //class containing logging functionality
    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}