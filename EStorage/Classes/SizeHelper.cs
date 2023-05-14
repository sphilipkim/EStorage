using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace EStorage.Classes
{
    public static class SizeHelper
    {
        private static string sizePath = ".\\Sizes.txt";
        private static string sPath = ".\\SizesShort.txt";

        public static List<string> readSizeFile()
        {
            //Read Sizes.txt file list
            if (File.Exists(sizePath))
            {
                //Set itemsizes
                return new List<string>(File.ReadAllLines(sizePath));
            }
            else
            {
                throw new FileNotFoundException("Sizes.txt does not exist. Please create or import the file.");
            }
        }

        public static List<string> readSizeShortFile()
        {
            //Read SizesShort.txt file list
            if (File.Exists(sPath))
            {
                //Set itemsizes
                return new List<string>(File.ReadAllLines(sPath));
            }
            else
            {
                throw new FileNotFoundException("SizesShort.txt does not exist. Please create or import the file.");
            }
        }


        public static string getSize(string text, List<string> sList, List<string> sizeList)
        {
            string ret = "";

            text = text.Trim().ToLower();

            string[] tokens = text.Split(' ');
            string t = tokens[tokens.Length - 1];

            //Make sure number of iSizes and itemSizes are the same
            if (sList.Count() == sizeList.Count())
            {
                //Check if token is in iSizes
                for (int i = 0; i < sizeList.Count(); i++)
                {
                    if (t.Equals(sList[i]))
                    {
                        return sizeList[i];
                    }
                }
            }


            return null;
        }
    }
}


