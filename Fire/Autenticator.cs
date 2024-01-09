using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    internal class Autenticator
    {
        public bool DataAutenticator(string message, string casemassage, Utilizador useraux)
        {
            UserFile filecheck = new UserFile(useraux._name);
            var user2 = filecheck.GetFromFile();
            if (user2 == null)
                return false;
            else if (user2._Password == useraux._Password && message.Equals(casemassage, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            else return false;
        }
    }
}