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
    public class Ren
    {
        public static void Rename(string original,string newname)
        {
            if (FTPManager.IsConnected)
            {
                try
                {
                    FtpWebRequest ftpRequest = (FtpWebRequest)(WebRequest.Create($"ftp://{FTPManager.IP}/{original}"));
                    ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                    ftpRequest.RenameTo = newname;
                    ftpRequest.UseBinary = true;
                    ftpRequest.KeepAlive = true;
                    if (FTPManager.USER != "" && FTPManager.PASS != "")
                        ftpRequest.Credentials = new NetworkCredential(FTPManager.USER, FTPManager.PASS);
                    FtpWebResponse resp = null;
                    resp = (FtpWebResponse)(ftpRequest.GetResponse());
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
            Console.WriteLine(string.Format(Logger.GetMessage("SUCCESSFUL_RENAME"), original,newname, FTPManager.IP), Color.Green);

        }
    }
}
