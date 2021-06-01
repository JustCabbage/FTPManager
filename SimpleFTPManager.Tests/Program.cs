using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace SimpleFTPManager.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage);
            Console.WriteLine();
            CreateDir.CreateDirectory("test/testingFTP");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test")));
            Console.WriteLine();
            DeleteDir.DeleteDirectory("test/testingFTP");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test")));

        }
    }
}