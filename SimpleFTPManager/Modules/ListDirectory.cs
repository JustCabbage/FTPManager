using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleFTPManager;
using SimpleFTPManager.Logging;
using Console = Colorful.Console;

namespace SimpleFTPManager.Modules
{
    public class ListDir
    {
        public static string[] ListDirectory(string directory)
        {
            if (FTPManager.IsConnected)
            {

                FtpWebResponse resp = Utils.Utils.MethodConnection(WebRequestMethods.Ftp.ListDirectory, directory);
                List<string> dir = new List<string>();
                using (var files = new StreamReader(resp.GetResponseStream()))
                {
                    string file;
                    while ((file = files.ReadLine()) != null)
                    {
                        dir.Add(file);
                    }
                }
                return dir.ToArray();
            }
            else
            {
                Console.WriteLine(Logger.GetMessage("NOT_CONNECTED"), Color.Crimson);
                return new string[] { };
            }
        }
    }
}
