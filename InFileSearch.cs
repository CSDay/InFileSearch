using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace inFileSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFound = false;
            try
            {
                Console.Write("input folder location > ");
                string loc = Console.ReadLine();
                Console.Write("Input word > ");
                string wordToFind = Console.ReadLine();
                string[] files = Directory.GetFiles(loc);
                

                foreach (string str in files)
                {
                    if ((Path.GetExtension(str) == ".txt") || (Path.GetExtension(str) == ".json"))
                    {
                        //Console.WriteLine(str);
                        StreamReader sr = new StreamReader(str);
                        //Console.WriteLine(sr.ReadToEnd());
                        string stream = sr.ReadToEnd();
                        List<string> wordList = new List<string>();
                        wordList = stream.Split(' ').ToList();
                        foreach(string wStr in wordList)
                        {
                            if (wStr.ToLower() == wordToFind.ToLower())
                            {
                                Console.WriteLine("Word found in {0}", str);
                                isFound = true;
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine("{0} not readable", str);
                    }
                }
            }

            catch
            {
                Console.WriteLine("Error: Folder Not Found");
            }

            Console.WriteLine("Search Complete");
            if (!isFound)
                Console.WriteLine("File Not found");
            Console.ReadLine();
        }
    }
}
