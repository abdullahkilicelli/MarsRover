using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarsRoverConsoleApp
{
    class FileOperation
    {
        public string[] ReadFile(string path)
        {
            string[] lines;
            try
            {
                if (File.Exists(path))
                {
                    lines = File.ReadAllLines(path);
                    return lines;
                }
                else
                {
                    throw new Exception("ERROR: File Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERROR:\n ({ex.Message})");
            }
        }
    }
}
