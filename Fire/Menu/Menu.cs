using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Fire.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
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
            IFile.basecategory = AdminFile.LoadBaseDir();
            if (AdminFile.LoadBaseDir() == "Toconfig")
            {
                Console.WriteLine("Por favor, configure a diretoria base!");
                Console.WriteLine("-----------------------------------------");
                Adminmenu();
                IFile.basecategory = AdminFile.LoadBaseDir();
            }
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
                        else if (utilizador._name == "Admin" && utilizador._password == "Admin")
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
            else if (x == 2)
            {
                UserExpenses();
            }
        }
        static void Adminmenu()
        {
            while (true)
            {
                Console.WriteLine("Bem-Vindo Admin!");
                Console.WriteLine("-----------------");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine(" 1 - Definir diretoria base\r\n" +
                    " 2 - Importar Categorias\r\n" +
                    " 3- Estatísticas de todos os utilizadores\r\n" +
                "4- Voltar");
                int x = Console2.Readint();
                if (x == 1)
                {
                    AdminFile file = new AdminFile();
                    file.SetBaseCategory();
                    Console2.StringSleep("Estamos prontos para começar!", 2);
                    Console.Clear();
                    continue;
                }
                if (x == 2)
                {
                    CategoriesFile file = new CategoriesFile("expenseses-categories", ".txt");
                    file.ImportCategories(file.filename, file.extension);
                    Console2.StringSleep("Categorias do utilizador importadas com sucesso!", 2);
                    continue;
                }
                if (x == 3)
                {
                }
                if (x == 4)
                {
                    break;
                }
            }
        }


        public static void UserEdit(Utilizador user)
        {
            while (true)
            {
                Console.Clear();
                string comando = "fire set -user";
                Console.WriteLine($"Utilize o comando {comando} --help) para informaçoes sobre os comandos");
                Console.WriteLine("Insira o comando!");

                var command = Console.ReadLine().Split(" ");
                var atributes = UserEditorFunc.AtributesParse(command);
                command = UserEditorFunc.CommandParse(command, atributes);
                string x = string.Join("", command);
                if (x.Equals(comando.Replace(" ", ""), StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    UserEditorFunc.CommandApplier(user, atributes);
                }
                else
                {
                    Console2.StringSleep("Comando invalido! insira de novo", 1);
                    continue;

                }
            }

        }
        public static void UserExpenses()
        {
            DespesaFile despesaFile = new DespesaFile("Despesas", ".csv");
            List<Despesa> despesauser = despesaFile.ImportDespesa();
            decimal x = 0;
            if (despesauser == null)
            {
                Console.WriteLine("Voce não tem despesas associadas ao sistema");
            }
            else
            {
                foreach (var despesa in despesauser)
                {
                    Console.WriteLine($"Data : {despesa.data} \n" +
                        $"Categoria : {despesa.categoria}\n" +
                        $"Sub categoria: {despesa.subcategoria}\n" +
                        $"Benificiario: {despesa.beneficiario}\n" +
                        $"Descrição : {despesa.descricao}\n" +
                        $"Valor : {despesa.valor}");
                    Console2.StringSleep("------------------", 1);
                    x += despesa.valor;

                }
                Console.WriteLine($"O valor total de despesas foi {x}");

            }
        }
    }
}
