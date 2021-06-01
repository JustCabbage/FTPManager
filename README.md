# FTPManager [![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://lbesson.mit-license.org/)


# What is FTPManager ?

This is just a simple proof of concept of how FTP can be implemented in C#.

# What are FTPManager's features ?

- [+] Create a directory
- [+] List a directory 
- [+] Delete a directory
- [+] Custom logging system
- [+] Modularity with the MethodConnection() function

# Examples:

## Basic Connection
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CreateDir.DeleteDirectory("test/testingFTP");
            Console.WriteLine(string.Join(" , ", ListDir.ListDirectory("/test"))); // ListDirectory returns a string[], which can be printed onto the console like this.
        }
    }
}
```
