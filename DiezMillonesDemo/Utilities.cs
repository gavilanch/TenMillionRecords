using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiezMillonesDemo
{
    internal class Utilities
    {
        public static void CreateFileWithData(int records, string route)
        {

            if (File.Exists(route))
            {
                File.Delete(route);
            }

            using (StreamWriter writer = new StreamWriter(route, append: true))
                for (int i = 1; i <= records; i++)
                {
                    {
                        writer.WriteLine($"value {i}");
                    }
                }

        }

        public static void Warmup(string route)
        {
            CreateFileWithData(1, route);
            EfficientCode.InsertData(route);
        }
    }
}
