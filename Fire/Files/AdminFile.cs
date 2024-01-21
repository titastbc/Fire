using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Files
{
    class AdminFile : IFile
    {
        public AdminFile()
        {
            path = "Fire\\FireAdminInfo";
            this.filename = "Admin";
            this.extension = ".json";
            FullPath = Path.Combine(basecategory, path, filename + extension);
        }

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

        public void SetBaseCategory()
        {
            string basefiles = "C:\\Fire\\bin\\Debug\\net8.0";
            while (true)
            {
                Console.WriteLine("Insira a categoria base");
                string newbase = Console.ReadLine();
                try
                {
                    File.WriteAllText("BaseDir.txt",newbase);
                    Createfiles(newbase);
                    File.Copy(basefiles + "\\Admin.json", newbase + "\\Fire\\FireAdminInfo\\Admin.json", true);
                    File.Copy(basefiles + "\\Despesas.csv", newbase + "\\Fire\\FireUserExpenses\\Despesas.csv", true);
                    File.Copy(basefiles + "\\expenseses-categories.txt", newbase + "\\Fire\\FireCategories\\expenseses-categories.txt", true);
                    break;
                }
                catch (Exception ex)
                {
                    Console2.StringSleep(ex.Message + ", Tente de novo",2);
                    Console.Clear();
                }
            }
        }
        public static string LoadBaseDir()
        {
            var txt = File.ReadAllText("C:\\Fire\\bin\\Debug\\net8.0" + "\\BaseDir.txt");
            return txt;
        }
    }
}
