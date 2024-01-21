using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    public class Calculator
    {
        public static int LongevidadeRestante(Utilizador user)
        {
            string data2 = DateTime.UtcNow.Date.ToString();
            var data3 = data2.Split(" ");
            var dataatual = DateOnly.Parse(data3[0]);
            var idade = dataatual.Year - user._birthDate.Year;
            var longrestante = user.longevidade - idade;
            return longrestante;
        }
        public static double CalcularAposentadoria(Utilizador user)
        {
            if (user.inflação != 0 || user.dispesamediamensal != 0)
            {
                var restante = LongevidadeRestante(user);
                var dispesaanual = user.dispesamediamensal * 12;
                double patrimoniosemdespesa = 0;
                var sub = user.montanteTotalPatrimonio;
                for (int i = 0; i < restante; i++)
                {
                    var aux2 = user.montanteTotalPatrimonio * (user.rendimentoexpectavel / 100);
                    sub = user.montanteTotalPatrimonio + aux2;
                    var aux = dispesaanual;
                    dispesaanual *= (user.inflação / 100);
                    dispesaanual += aux;
                    patrimoniosemdespesa = sub - dispesaanual;


                }
                patrimoniosemdespesa = patrimoniosemdespesa / (12 * restante);
                    return patrimoniosemdespesa;
                
                
            }
            else Console.WriteLine("Inflação ou dispesa mensal são 0, edite primeiro os seus dados");
            return 0;
        }

        public static double CalcularRacio(Utilizador user)
        {
            var mensal = CalcularAposentadoria(user);
            var racio = mensal / user.dispesamediamensal;
            return racio;
        }
    }

}
