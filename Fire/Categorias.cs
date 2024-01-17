using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{

    internal class Categoria
    {
        public string name;
        public List<Categoria> subcategorias = new List<Categoria>();
        public Categoria(string _name)
        {
            name = _name ;
        }

    }
}
