using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    class AdminFile : IFile
    {
        public string path = @"C:\FireAdminInfo";
        public string filename = "Admin.json";
        public string FullPath;
        public AdminFile() { FullPath = Path.Combine(path, filename); }

        public Utilizador GetFromFile()
        {
            var json = File.ReadAllText(FullPath);
           var admin = System.Text.Json.JsonSerializer.Deserialize<Utilizador>(json);
            return admin;
        }

        public void SendToFile(Utilizador user)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(user);
            File.WriteAllText(FullPath, json);
        }
    }
}
