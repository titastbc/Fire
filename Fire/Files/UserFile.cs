using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fire.Files
{
    internal class UserFile : IFile
    {
        public UserFile(string filename, string extension)
        {
            path = "Fire\\FireUserInfo";
            this.filename = filename;
            this.extension = extension;
            FullPath = Path.Combine(basecategory,path, filename + extension);
        }

        public static bool UserFileCheck(string filename, string extension)
        {
            UserFile userfile = new UserFile(filename, extension);
            return File.Exists(userfile.FullPath);
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
        public static void DeleteUser(string filename)
        {
            UserFile delete = new UserFile(filename, ".json");
            if (File.Exists(delete.FullPath) == true)
            {
                File.Delete(delete.FullPath);
            }
            else return;
        }

        public static void ImportUser()
        {
            List<Utilizador> users = new List<Utilizador>();
           String[] filenames = Directory.GetFiles(basecategory + "\\Fire\\FireUserInfo");
            foreach (String filename in filenames)
            {
                var txt = File.ReadAllLines(filename);
            }
        }
    }
}
