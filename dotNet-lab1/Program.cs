using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name");
            var fileName = Console.ReadLine();
            string tempPath = $"C:\\temp\\{fileName}";
            Console.WriteLine("Enter the keyworld");
            var keyworld = Console.ReadLine();
            Console.WriteLine("Enter the source file");
            var sourceFile = Console.ReadLine();

            checkVariable("filename", fileName);
            checkVariable("keyworld", keyworld);
            checkVariable("sourcefile", sourceFile);

            if (!File.Exists(sourceFile))
            {
                throw new Exception($"file {sourceFile} does not exist");
            }

            using (StreamWriter sw = File.CreateText(fileName))
            {
                var rnd = new Random();
                var count = rnd.Next(10001) + 1;

                for (int i = 0; i < count; ++i)
                {
                    sw.Write(keyworld);
                }

                var fi = new FileInfo(sourceFile);
                if (fi.Length > 10000000)
                {
                    string text = File.ReadAllText(sourceFile);
                    sw.Write(text);
                }
            }


        }

        private static void checkVariable(string variableName, string variable)
        {
            if (string.IsNullOrEmpty(variable))
            {
                throw new Exception($"Your {variable} parameter is empty");
            }



        }
    }
}
