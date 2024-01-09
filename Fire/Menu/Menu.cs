using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fire.Menu
{
    class Menu
    {
        public static void MainMenu()
        {
            BemVindo();
            while (true)
            {
                int x = RegLog();
                if (x == 1)
                {
                    Register();
                    Console.WriteLine("Registo efectuado com sucesso!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
                else if (x == 2)
                {
                    Utilizador utilizador = LogIn();

                    if (utilizador == null)
                    {
                        Console.WriteLine("LogIn invalido! tente de novo");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }

                    else if (utilizador != null)
                    {
                        Console.Clear();
                        if (utilizador._name != "Admin")
                        {
                            UserMenu(utilizador);
                            break;
                        }
                        else if (utilizador._name == "Admin" && utilizador._Password == "Admin")
                            Adminmenu();
                        break;

                    }
                }
                else if (x >= 0 || x <= 3)
                {
                    Console.WriteLine("Seleção invalida! tente de novo");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
            }
            static void BemVindo()
            {
                Console.WriteLine("Bem vindo á Fire!");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Cuidamos das suas Finanças!");
                Console.WriteLine();
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine();
            }

            static int RegLog()
            {
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine("1 - Registo");
                Console.WriteLine("2 - Login");
                int x = Console2.Readint2();
                return x;
            }
            static void Register()
            {
                while (true)
                {
                    var user = AskData();
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
                    break;
                }

            }

            static Utilizador LogIn()
            {
                IFile filecheck;
                Utilizador user2;
                var useraux = AskData();
                if (useraux._name != "Admin" && useraux._name != "admin")
                {
                    filecheck = new UserFile(useraux._name);
                    user2 = filecheck.GetFromFile();
                }
                else
                {
                    AdminFile adminfile = new AdminFile();
                    user2 = adminfile.GetFromFile();
                    if (useraux._Password == user2._Password && useraux._name.Equals(user2._name, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return user2;
                    }
                }
                if (user2 == null)
                    return null;
                else if (user2._Password == useraux._Password && useraux._name.Equals(user2._name, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return user2;
                }
                else return null;
            }
            static Utilizador AskData()
            {
                Utilizador user = new Utilizador();
                Console.WriteLine("Nome de utilizador:");
                user._name = Console.ReadLine();
                Console.WriteLine("Password:");
                user._Password = Console.ReadLine();
                return user;
            }
            static void UserMenu(Utilizador user)
            {
                Console.WriteLine($"Bem-Vindo {user._name}");
                Console.WriteLine("-----------------");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Editar Utilizador\r\n 2 - Importar despesas\r\n 3 - Dashboard ");
            }
            static void Adminmenu()
            {
                Console.WriteLine("Bem-Vindo Admin!");
                Console.WriteLine("-----------------");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine(" 1 - Definir diretoria base\r\n" +
                    " 2 - Importar Categorias\r\n" +
                    " 3- Estatísticas de todos os utilizadores\r\n");
            }
        }
    }
}
