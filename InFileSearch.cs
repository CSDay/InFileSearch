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
            //Used to give the user one final warning that nothing was found
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
                    //The two main file formats used by cataclysm DDA
                    if ((Path.GetExtension(str) == ".txt") || (Path.GetExtension(str) == ".json"))
                    {
                        //This comment intentionally left blank
                        StreamReader sr = new StreamReader(str);
                        string stream = sr.ReadToEnd();
                        List<string> wordList = new List<string>();
                        wordList = stream.Split(' ').ToList();
                        foreach (string wStr in wordList)
                        {
                            if (wStr.ToLower() == wordToFind.ToLower())
                            {
                                //No line number given in page, but can use ctrl+f to find the specific word
                                Console.WriteLine("Word found in {0}", str);
                                isFound = true;
                            }
                        }
                    }
                }
            }
            
            //No need to get the info on the exception since there is only one possible exception here
            catch
            {
                Console.WriteLine("Error: Folder Not Found");
            }

            Console.WriteLine("Search Complete");

            if (!isFound)
            {
                Console.WriteLine("File Not found");
            }
            Console.ReadLine();
        }
    }
}
