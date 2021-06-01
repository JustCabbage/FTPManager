using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;
using SimpleFTPManager.Logging;

namespace SimpleFTPManager
{
    public class FTPManager
    {

        public FtpWebResponse Initialise(string IP,int port = 21,string username = "",string password = "")
        {
            Console.Clear();
            Console.WriteLine("Cabbage's FTP Manager 1.0\n",Color.Magenta);
            destinationIP = IP;
            destinationPORT = port;
            if (username != "") usernameCredential = username;
            if (password != "") passwordCredential = password;
            FtpWebRequest ftpRequest = (FtpWebRequest)(WebRequest.Create($"ftp://{destinationIP}"));
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = true;
            if (usernameCredential != "" && passwordCredential != "")
                ftpRequest.Credentials = new NetworkCredential(usernameCredential, passwordCredential);
            FtpWebResponse resp = null;
            try
            {
                resp = (FtpWebResponse)(ftpRequest.GetResponse());
           
            }catch(Exception e){
                Console.WriteLine(Logger.GetMessage("UNABLE_TO_CONNECT"),Color.Red);
                IsConnected = false;
                return resp;
            }
            IsConnected = true;
            Console.WriteLine(Logger.GetMessage("SUCCESSFUL_CONNECTION"),Color.Green);
            return resp;
        }


        public static bool IsConnected { get; set; }

        private static string destinationIP;
        public static string IP { get { return destinationIP; } }

        private static int destinationPORT;
        public static int PORT { get { return destinationPORT; } }

        private static string usernameCredential;
        public static string USER { get { return usernameCredential; } }

        private static string passwordCredential;
        public static string PASS { get { return passwordCredential; } }

    }
}
