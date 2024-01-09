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
        public string _Password { get; set; }
        public DateOnly _BirthDate;
        public double MontanteTotalPatrimonio;
        public double dispesamediamensal;
        public double randimentoexpectavel;
        public double inflação;
        public int longevidade;
    }
}
