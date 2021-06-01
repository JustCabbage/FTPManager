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
            Ren.Rename("/test/testingFTP", "/test/testingFTPRename");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test")));
            Console.WriteLine();
            DeleteDir.DeleteDirectory("test/testingFTPRename");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test")));
            Console.WriteLine();
            Console.WriteLine(ListDirDetail.ListDirectoryDetails("/test"));
            Download.DownloadFile("/test/index.html", "./index.html");
            Console.WriteLine();
            Upload.UploadFile("./index.html", "/test/index.html");

        }
    }
}