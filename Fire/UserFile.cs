using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    internal class UserFile : IFile
    {
        public string path = @"C:\FireUserInfo";
        public string filename;
        public string FullPath;
        public UserFile(string filename)
        {
            this.filename = filename;
            this.FullPath = Path.Combine(path, filename + ".json");
        }

        public void SendToFile(Utilizador user)
        {

            string json = System.Text.Json.JsonSerializer.Serialize(user);
            File.WriteAllText(FullPath, json);
        }
        public Utilizador GetFromFile()
        {
            var user = new Utilizador();
            if (File.Exists(FullPath) == true)
                {
                var json = File.ReadAllText(FullPath);
                user = System.Text.Json.JsonSerializer.Deserialize<Utilizador>(json);
            }
            else
            {
                user = null;
            }
            return user;
        }
    }
}
