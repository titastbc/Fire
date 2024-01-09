using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    Autenticator.RegisterData();
                    break;
                }

            }

            static Utilizador LogIn()
            {
                var useraux = Autenticator.LogInAutenticator();
                return useraux;
            }

        }
        static void UserMenu(Utilizador user)
        {
            Console.WriteLine($"Bem-Vindo {user._name}");
            Console.WriteLine("-----------------");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Editar Utilizador\r\n 2 - Importar despesas\r\n 3 - Dashboard ");
            int x = Console2.Readint2();
            if (x == 1)
            {
                UserEdit(user);
            }
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


        public static void UserEdit(Utilizador user)
        {
            while (true)
            {
                Console.Clear();
                string comando = "fire set -user";
                Console.WriteLine($"Utilize o comando {comando} --help) para informaçoes sobre os comandos");
                Console.WriteLine("Insira o comando!");
                string command = Console.ReadLine();
                var command2 = command.Split(" ");
                string x = command2[0] + command2[1] + command2[2];
                if (x.Equals(comando.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    string[] atributes = command2;
                    int aux = 0;
                    for (int i = 3; i < command2.Length; i++)
                    {
                        atributes[aux] = command2[i].Replace("--", "");
                        aux++;
                    }
                    for (int i = 0; i < command2.Length; i += 2)
                    {
                        for (int j = 1; j < command2.Length; j += 2)
                        {
                            switch (atributes[i])
                            {
                                case "help":
                                    Console.WriteLine("fire set-user \r\n" +
                                        "--name Nome Investidor\r\n" +
                                        "--pwd password\r\n" +
                                        "--db data de nascimento usando o formato dd-mm-yyyy ou yyyy-mm-dd\r\n" +
                                        "--assets valor total património\r\n--expenses média mensal de despesas\r\n" +
                                        "--yield taxa de retorno esperada [0, 1]\r\n" +
                                        "--inflation taxa de inflação [0,1]\r\n" +
                                        "--ttl longevidade prevista em anos");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case "name":
                                    user._name = command2[j];
                                    Console.WriteLine("Nome alterado com sucesso!");
                                    Thread.Sleep(1000);
                                    i = command2.Length;
                                    j = command2.Length;
                                    break;
                                case "password":
                                    user._Password = command2[j];
                                    break;
                                case "db":
                                    DateOnly date;
                                    if (DateOnly.TryParse(command2[j], out date))
                                    {
                                        user._BirthDate = date;
                                        break;
                                    }
                                    else Console.WriteLine("Formato de data ivalido, formato correto : yyyy-MM.dd");
                                    continue;

                            }

                        }


                    }


                }
                else
                {
                    Console.WriteLine("Comando invalido! insira de novo");
                    continue;

                }


            }

        }
    }
}

//if (command == "fire set - user--help") ;
//{
//    Console.Clear();
//    Console.WriteLine("fire set-user \r\n" +
//        "--name Nome Investidor\r\n" +
//        "--pwd password\r\n" +
//        "--db data de nascimento usando o formato dd-mm-yyyy ou yyyy-mm-dd\r\n" +
//        "--assets valor total património\r\n" +
//        "--expenses média mensal de despesas\r\n" +
//        "--yield taxa de retorno esperada [0, 1]\r\n" +
//        "--inflation taxa de inflação [0,1]\r\n" +
//        "--ttl longevidade prevista em anos\r\n");
//    Console.ReadLine();
//    Console.Clear();
//    continue;
//}