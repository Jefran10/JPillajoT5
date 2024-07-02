using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avillarroelS5.Utils
{
    public class FileAccessHelp
    {
        public static string GetLocalFilePath(string filename)
        {

            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
