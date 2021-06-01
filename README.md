# FTPManager [![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://lbesson.mit-license.org/)


# What is FTPManager ?

This is just a simple proof of concept of how FTP can be implemented in C#.

# What are FTPManager's features ?

- [+] Create a directory
- [+] List a directory and its subfolder details
- [+] Delete a directory
- [+] Rename files and directories
- [+] Download and Upload files
- [+] Custom logging system
- [+] Modularity with the MethodConnection() function

# Examples:

## Basic Connection
```csharp
using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage); // Initialise returns a FtpWebResponse
        }
    }
}
```
## Directory Creation and Directory Listing
```csharp
using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage); // Initialise returns a FtpWebResponse
            CreateDir.CreateDirectory("test/testingFTP");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test"))); // ListDirectory returns a string[], which can be printed onto the console like this.
        }
    }
}
```
## Directory Deletion
```csharp
using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage); // Initialise returns a FtpWebResponse
            DeleteDir.DeleteDirectory("test/testingFTP");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test"))); // ListDirectory returns a string[], which can be printed onto the console like this.
        }
    }
}
```

## List Directory Details
```csharp
using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage); // Initialise returns a FtpWebResponse
            ListDirDetail.ListDirectoryDetails("test/testingFTP");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test"))); // ListDirectory returns a string[], which can be printed onto the console like this.
        }
    }
}
```


## Rename
```csharp
using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage); // Initialise returns a FtpWebResponse
            Ren.Rename("/test/testingFTP/","/test/testingFTPRename");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test"))); // ListDirectory returns a string[], which can be printed onto the console like this.
        }
    }
}
```


## Upload and Download Files
```csharp
using System;
using SimpleFTPManager;
using SimpleFTPManager.Modules;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FTPManager ftp = new FTPManager();
            Console.WriteLine(ftp.Initialise("127.0.0.1", 21, "optionalUser", "optionalPass").WelcomeMessage); // Initialise returns a FtpWebResponse
            Upload.UploadFile("./file.txt","/test/testingFTP/file.txt");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test/testingFTP"))); // ListDirectory returns a string[], which can be printed onto the console like this.
            Download.DownloadFile("/test/testingFTP/file.txt","./file.txt");
        }
    }
}
```
