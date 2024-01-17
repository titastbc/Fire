using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fire.Files;

namespace Fire
{
    internal class UserEditorFunc
    {


        public static string[] AtributesParse(string[] command)
        {
            int maxindex = command.Length;
            string[] atributes = null;
            for (int i = 0; i < maxindex - 1; i++)
            {
                if (command[i].Equals("user", StringComparison.OrdinalIgnoreCase) || command[i].Equals("-user", StringComparison.OrdinalIgnoreCase))
                {

                    var posição = i + 1;
                    atributes = new string[maxindex - posição];
                    for (int j = 0; j < atributes.Length; j++)
                    {
                        atributes[j] = command[posição];
                        posição++;
                    }
                }
            }
            return atributes;
        }
        public static string[] CommandParse(string[] command, string[] atributes)
        {
            int maxindex = command.Length;
            var aux = new string[maxindex - atributes.Length];
            for (int j = 0; j < aux.Length; j++)
            {
                aux[j] = command[j];
            }
            command = aux;
            return command;
        }
        public static void CommandApplier(Utilizador user, string[] atributes)
        {
            if (atributes == null)
            {
                Console2.StringSleep("Comando nulo ou invalido! insira de novo", 1);
                return;

            }
            for (int i = 0; i < atributes.Length; i += 2)
            {
                int j = i + 1;
                if (atributes[i] == "--")
                {
                    Console.WriteLine($"Comando errado! coloce tudo junto, exemplo: --{atributes[i + 1]}");
                    continue;

                }
                if (atributes[i].ToLower() == "--help")
                {
                    Console.WriteLine("fire set-user \r\n" +
                        "--name Nome Investidor\r\n" +
                        "--pwd password\r\n" +
                        "--db data de nascimento usando o formato dd-mm-yyyy ou yyyy-mm-dd\r\n" +
                        "--assets valor total património\r\n" +
                        "--expenses média mensal de despesas\r\n" +
                        "--yield taxa de retorno esperada [0, 1]\r\n" +
                        "--inflation taxa de inflação [0,1]\r\n" +
                        "--ttl longevidade prevista em anos");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                if (atributes[i].ToLower() == "--name")
                {
                    if (UserFile.UserFileCheck(atributes[j], ".json") == false)
                    {
                        UserFile send = new UserFile(atributes[j],".json");
                        send.SendToFile(user);
                        UserFile.DeleteUser(user._name);
                        user._name = atributes[j];
                        Console2.StringSleep("Nome alterado com sucesso!", 2);

                    }
                    else Console2.StringSleep("Nome ja em utilização, escolha outro!", 1);
                    continue;
                }
                if (atributes[i].ToLower() == "--password")
                {
                    user._password = atributes[j];
                    Console2.StringSleep("password alterado com sucesso!", 2);
                    continue;
                }
                if (atributes[i].ToLower() == "--db")
                {
                    DateOnly date;
                    if (DateOnly.TryParse(atributes[j], out date))
                    {
                        user._birthDate = date;
                        Console2.StringSleep("data de nascimento alterada com sucesso!", 2);
                        continue;
                    }
                    else Console2.StringSleep("Formato de data ivalido, formato correto : yyyy-MM.dd", 1);
                    continue;
                }
                if (atributes[i].ToLower() == "--assets")
                {
                    user.montanteTotalPatrimonio = Console2.ReadDecimal(atributes[j]);
                    Console2.StringSleep("Valor total do patrimonio alterado com sucesso!", 2);
                    continue;

                }
                if (atributes[i].ToLower() == "--expenses")
                {
                    user.dispesamediamensal = Console2.ReadDecimal(atributes[j]);
                    Console2.StringSleep("expenses alteradas com sucesso!", 2);
                    continue;

                }
                if (atributes[i].ToLower() == "--yield")
                {
                    user.rendimentoexpectavel = Console2.ReadDecimal(atributes[j]);
                    Console2.StringSleep("Taxa de retorno esperada alterada com sucesso!", 2);

                }
                if (atributes[i].ToLower() == "--inflation")
                {
                    user.inflação = Console2.ReadDecimal(atributes[j]);
                    Console2.StringSleep("inflação alterada com sucesso!", 2);

                }
                if (atributes[i].ToLower() == "--ttl")
                {
                    int num = Console2.Readint2(atributes[j]);
                    if (num == 0 || num >= 150)
                        Console2.StringSleep("Valor invalido! Introduza de novo", 1);
                    else
                        user.longevidade = num;
                    Console2.StringSleep("Longevidade alterada com sucesso!", 2);
                }
                else Console2.StringSleep("Comando invalido!", 2);
            }
            UserFile userFile = new UserFile(user._name,".json");
            userFile.SendToFile(user);
        }
    }
}





