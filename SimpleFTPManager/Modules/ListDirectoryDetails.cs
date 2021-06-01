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
using System.IO;

namespace SimpleFTPManager.Modules
{
    public class ListDirDetail
    {
        public static string ListDirectoryDetails(string directory)
        {
            if (FTPManager.IsConnected)
            {
                FtpWebResponse resp = Utils.Utils.MethodConnection(WebRequestMethods.Ftp.ListDirectoryDetails,directory);
                return new StreamReader(resp.GetResponseStream()).ReadToEnd();
            }
            else
            {
                Console.WriteLine(Logger.GetMessage("NOT_CONNECTED"), Color.Crimson);
                return "";
            }

        }
    }
}
