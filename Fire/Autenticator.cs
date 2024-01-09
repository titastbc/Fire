using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    internal class Autenticator
    {
        public static Utilizador RegisterData()
        {
            while (true)
            {

                Utilizador user = new Utilizador();
                Console.WriteLine("Nome de utilizador:");
                user._name = Console.ReadLine();
                Console.WriteLine("Password:");
                user._Password = Console.ReadLine();
                Console.WriteLine("Data de nascimento:");
                string date = Console.ReadLine();
                DateOnly date2;
                if (DateOnly.TryParse(date, out date2))
                {
                    user._BirthDate = date2;
                }
                else
                {
                    Console.WriteLine("Formato de data ivalido, formato correto : yyyy-MM.dd");
                    continue;

                }
                if (user._name == "Admin" || user._name == "admin")
                {
                    Console.WriteLine("Nome inválido! Insira de novo");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
                UserFile send = new UserFile(user._name);
                if (File.Exists(send.FullPath) == true)
                {
                    Console.WriteLine("O nome de utilizador ja existe, tente colocar outro");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
                send.SendToFile(user);
                return user;

            }
        }
        public static Utilizador LogInAutenticator()
        {
            while (true)
            {
                IFile filecheck;
                Utilizador user2;
                Utilizador user = new Utilizador();
                Console.WriteLine("Nome de utilizador:");
                user._name = Console.ReadLine();
                Console.WriteLine("Password:");
                user._Password = Console.ReadLine();
                if (user._name != "Admin" && user._name != "admin")
                {
                    filecheck = new UserFile(user._name);
                    user2 = filecheck.GetFromFile();
                }
                else
                {
                    AdminFile adminfile = new AdminFile();
                    user2 = adminfile.GetFromFile();
                    if (user._Password == user2._Password && user._name.Equals(user2._name, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return user2;
                    }
                }
                if (user2 == null)
                    return null;
                else if (user2._Password == user._Password && user._name.Equals(user2._name, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return user2;
                }
                else return null;

            }
        }

    }
}