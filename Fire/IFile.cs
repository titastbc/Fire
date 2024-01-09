using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    interface IFile
    {
        public void SendToFile(Utilizador user);
        public Utilizador GetFromFile();
    }
}
