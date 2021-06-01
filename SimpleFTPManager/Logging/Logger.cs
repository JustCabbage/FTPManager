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
                                                                                                { "NOT_CONNECTED", $"The FTPManager has not been initialised, or is not connected to a valid server. Please try again!" },
                                                                                                { "SUCCESSFUL_CONNECTION", $"Successfully connected to Server: {FTPManager.IP} on Port: {FTPManager.PORT}" }, 
                                                                                                { "SUCCESSFUL_CREATE_DIR", "Successfully created Directory {0} on Server: {1}" },
                                                                                                { "SUCCESSFUL_REMOVE_DIR", "Successfully removed Directory {0} on Server: {1}" },
                                                                                                { "DIRECTORY_ALREADY_EXISTS", "This directory already exists or permission is denied! Please try again." },
                                                                                                { "SUCCESSFUL_RENAME", "Successfully renamed {0} to {1} on Server: {2}" },
                                                                                                { "INVALID_FILE_PATH", "The file path provided is invalid, please try again." },
                                                                                                { "SUCCESSFUL_DOWNLOAD_FILE", "Successfully downloaded File: \"{0}\" to Path: \"{1}\" from Server: {2}" },
                                                                                                { "SUCCESSFUL_UPLOAD_FILE", "Successfully uploaded File: \"{0}\" to Path: \"{1}\" to Server: {2}" },
                                                                                                { "INSUFFICIENT_PERMISSIONS", "This file or directory doesn't exist or permission is denied! Please try again." },
            };
    }

}
