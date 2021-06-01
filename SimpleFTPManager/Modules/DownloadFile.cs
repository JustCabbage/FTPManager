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
    public class Download
    {
        public static void DownloadFile(string file,string path)
        {
            if (FTPManager.IsConnected)
            {
                try
                {
                    using(WebClient r = new WebClient())
                    {
                        r.Credentials = new NetworkCredential(FTPManager.USER, FTPManager.PASS);
                        byte[] buffer = r.DownloadData($"ftp://{FTPManager.IP}/{file}");
                        FileStream f = File.Create(path);
                        f.Write(buffer, 0, buffer.Length);
                        f.Close();
                    }
                    
                }
                catch(Exception e)
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
            Console.WriteLine(string.Format(Logger.GetMessage("SUCCESSFUL_DOWNLOAD_FILE"),  file,path, FTPManager.IP), Color.Green);

        }
    }
}
