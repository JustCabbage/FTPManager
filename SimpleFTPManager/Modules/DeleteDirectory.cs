﻿using System;
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
    public class DeleteDir
    {
        public static void DeleteDirectory(string directory)
        {
            if (FTPManager.IsConnected)
            {
                try
                {
                    FtpWebResponse resp = Utils.Utils.MethodConnection(WebRequestMethods.Ftp.RemoveDirectory, "/" + directory);
                    Console.WriteLine(string.Format(Logger.GetMessage("SUCCESSFUL_REMOVE_DIR"), "/" + directory, FTPManager.IP), Color.Green);
                }
                catch
                {
                    Console.WriteLine(Logger.GetMessage("INSUFFICIENT_PERMISSIONS"), Color.Red);
                    return;
                }
            }
            else
            {
                Console.WriteLine(Logger.GetMessage("NOT_CONNECTED"), Color.Crimson);
                return;
            }

        }
    }
}
