using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Files
{

    abstract class IFile
    {
        public static string basecategory;
        public string path;
        public string filename;
        public string extension;
        public string FullPath;

        public static void Createfiles(string basedir) 
        {
            var file = Directory.CreateDirectory(basedir + @"\Fire");
            Directory.CreateDirectory(file + @"\\FireUserInfo");
            Directory.CreateDirectory(file + @"\\FireAdminInfo");
            Directory.CreateDirectory(file + @"\\FireCategories");
            Directory.CreateDirectory(file + @"\\FireUserExpenses");
        }
}

}
