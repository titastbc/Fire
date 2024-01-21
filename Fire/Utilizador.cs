using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    public class Utilizador
    {
        public String _name { get; set; } 
        public string _password { get; set; }
        public DateOnly _birthDate { get; set; }
        public double montanteTotalPatrimonio { get; set; } 
        public double dispesamediamensal { get; set; }
        public double rendimentoexpectavel { get; set; }
        public double inflação { get; set; }
        public int longevidade { get; set; } = 100;
    }
}
