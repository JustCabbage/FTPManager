using SimpleFTPManager.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using Console = Colorful.Console;
using System.Threading.Tasks;

namespace SimpleFTPManager.Utils
{
    public class Utils
    {
        static public FtpWebResponse MethodConnection(string method,string path = "")
        {
            
            FtpWebRequest ftpRequest = (FtpWebRequest)(WebRequest.Create($"ftp://{FTPManager.IP}/{path}"));
            ftpRequest.Method = method;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = true;
            if (FTPManager.USER != "" && FTPManager.PASS != "")
                ftpRequest.Credentials = new NetworkCredential(FTPManager.USER, FTPManager.PASS);
            FtpWebResponse resp = null;

            resp = (FtpWebResponse)(ftpRequest.GetResponse());
            
            
            return resp;
        }




    }
}
