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
    public class Upload
    {
        public static void UploadFile(string localFile, string serverPath)
        {
            if (FTPManager.IsConnected)
            {
                try
                {
                    using (WebClient r = new WebClient())
                    {
                        r.Credentials = new NetworkCredential(FTPManager.USER, FTPManager.PASS);
                        r.UploadFile($"ftp://{FTPManager.IP}/{serverPath}", WebRequestMethods.Ftp.UploadFile, localFile);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(Logger.GetMessage("INVALID_FILE_PATH"), Color.Red);
                    return;
                }
            }
            else
            {
                Console.WriteLine(Logger.GetMessage("NOT_CONNECTED"), Color.Crimson);
                return;
            }
            Console.WriteLine(string.Format(Logger.GetMessage("SUCCESSFUL_UPLOAD_FILE"), localFile, serverPath, FTPManager.IP), Color.Green);

        }
    }
}
