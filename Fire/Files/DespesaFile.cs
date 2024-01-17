using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

namespace Fire.Files
{
    class DespesaFile : IFile
    {

        public DespesaFile(string filename, string extension)
        {
            this.path = @"\Fire\FireUserExpenses";
            this.filename = filename;
            this.extension = extension;
            FullPath = basecategory + Path.Combine(path, filename + extension);
        }

        public List<Despesa> ImportDespesa()
        {
            try
            {
                List<Despesa> despesas = new List<Despesa>();

                using (StreamReader reader = new StreamReader(FullPath))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {

                        string linha = reader.ReadLine();

                        string[] valores = linha.Split(';');

                        CategoriesFile file = new CategoriesFile("expenseses-categories", ".txt");
                        var txt = File.ReadAllLines(file.FullPath);

                        Despesa despesa = new Despesa
                        {
                            data = DateOnly.Parse(valores[0]),
                            categoria = valores[1],
                            subcategoria = valores[2],
                            beneficiario = valores[3],
                            descricao = valores[4],
                            valor = decimal.Parse(valores[5])

                        };
                        despesa.categoria = CategoriesFile.CategorieCheck(despesa.categoria, txt);
                        despesa.subcategoria = CategoriesFile.CategorieCheck(despesa.subcategoria, txt);
                        despesas.Add(despesa);
                    }
                    if (despesas.Count <= 0)
                        Console2.StringSleep("Ainda não tem despesas associadas, por isso o valor é 0.",2);
                    else
                    Console.WriteLine("Despesas importadas com sucesso!");
                    Console.WriteLine("-------------------");
                    Console.WriteLine();
                    return despesas;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao importar despesas: {ex.Message}");
                return null;
            }
        }
    }
}
