using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Fire
{
    internal class Despesa
    {
        [Name("data")]
        public DateOnly data { get; set; }
        [Name("categoria")]
        public string categoria { get; set; }
        [Name("subcategoria")]
        public string subcategoria { get; set; }
        [Name("beneficiario")]
        public string beneficiario { get; set; }
        [Name("descricao")]
        public string descricao { get; set; }
        [Name("valor")]
        public decimal valor { get; set; }
    }
}
