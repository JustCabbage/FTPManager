using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFTPManager.Logging
{
    class Logger
    {
        public static string GetMessage(string mess)
        {
            try
            {
                return Messages[mess];
            }
            catch
            {
                return "";
            }
        }
        private static Dictionary<string, string> Messages = new Dictionary<string, string>() { { "UNABLE_TO_CONNECT", $"Unable to connect to server with these details. Please try again." },
                                                                                                { "SUCCESSFUL_CONNECTION", $"Successfully connected to Server: {FTPManager.IP} on Port: {FTPManager.PORT}" }, 
                                                                                                { "SUCCESSFUL_CREATE_DIR", "Successfully created Directory {0} on Server: {1}" },
                                                                                                { "SUCCESSFUL_REMOVE_DIR", "Successfully removed Directory {0} on Server: {1}" },
                                                                                                { "DIRECTORY_ALREADY_EXISTS", "This directory already exists or permission is denied! Please try again." },
            };
    }

}
