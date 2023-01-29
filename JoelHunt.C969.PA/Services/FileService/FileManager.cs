﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoelHunt.C969.PA.Services.FileService
{
    class FileManager
    {
        private string path;
        private FileInfo file;
        public FileManager()
        {
            this.path = Application.StartupPath + "/Logs/login-log.txt";
            this.file = new System.IO.FileInfo(path);
            file.Directory.Create();
        }

        public void AddLog(string user)
        {
            string log = $"User {user} logged in at {DateTime.UtcNow}";
            
            using(StreamWriter writer = new StreamWriter(this.path))
            {
                writer.WriteLine(log);
                writer.Close();
            }
        }
    }
}
