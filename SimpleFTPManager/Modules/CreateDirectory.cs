using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using SimpleFTPManager;
using SimpleFTPManager.Logging;

namespace SimpleFTPManager.Modules
{
    public class CreateDir
    {
        public static void CreateDirectory(string directory)
        {
            if (FTPManager.IsConnected)
            {
                try
                {
                    FtpWebResponse resp = Utils.Utils.MethodConnection(WebRequestMethods.Ftp.MakeDirectory, "/" + directory);
                }
                catch
                {
                    Console.WriteLine(Logger.GetMessage("DIRECTORY_ALREADY_EXISTS"), Color.Red);
                    return;
                }
            }
            else
            {
                Console.WriteLine(Logger.GetMessage("NOT_CONNECTED"), Color.Crimson);
                return;
            }
            Console.WriteLine(string.Format(Logger.GetMessage("SUCCESSFUL_CREATE_DIR"), "/" + directory, FTPManager.IP),Color.Green);
           
        }
    }
}
