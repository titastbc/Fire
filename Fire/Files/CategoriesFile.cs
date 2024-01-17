using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Files
{
    internal class CategoriesFile : IFile
    {
        public CategoriesFile(string filename, string extension)
        {
            this.path = @"\Fire\FireCategories";
            this.filename = filename;
            this.extension = extension;
            FullPath = basecategory + Path.Combine(path, filename + extension);
        }

        public void SendToOtherFile(string Destination)
        {

            var txt = File.ReadAllLines(FullPath);
            File.WriteAllLines(Destination, txt);
        }

        public void ImportCategories(string Filename, string extension)
        {
            UserFile general = new UserFile(Filename, extension);
            SendToOtherFile(general.FullPath);
        }
        public static string CategorieCheck(string CategoriaDespesa, string[] categorias)
        {
            string aux = CategoriaDespesa;
            for (int i = 0; i < categorias.Length; i++)
            {
                categorias[i] = categorias[i].TrimStart();
                if (CategoriaDespesa.Equals(categorias[i], StringComparison.OrdinalIgnoreCase))
                {
                    aux = categorias[i];

                    return aux;
                }
                else aux = "Others";
            }
            return aux;

        }
    }
}
