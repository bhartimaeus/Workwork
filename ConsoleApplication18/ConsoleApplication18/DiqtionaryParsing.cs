using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MironsUtilBox
{
    public class ParseUtils
    {
        public static bool Diqtionary(string filename, out Dictionary<string, string> DiqOut)
        {
            var allText = File.ReadAllText(filename);
            char[] characters = allText.ToCharArray();
            DiqOut = new Dictionary<string, string>();
            bool isdonereading = false;
            int currIndex = 0;
            string denominator = "";
            string description = "";
            try
            {
                while (!isdonereading)
                {
                    if (characters[currIndex] == '{')
                    {
                        currIndex++;
                    }

                    if (characters[currIndex] == '"')
                    {
                        currIndex++;

                        while (characters[currIndex] != '"')
                        {
                            denominator += characters[currIndex];
                            currIndex++;
                        }
                    }

                    currIndex++;

                    if (characters[currIndex] == ':')
                    {
                        currIndex++;

                        if (characters[currIndex] == '"')
                        {
                            currIndex++;

                            while (characters[currIndex] != '"')
                            {
                                description += characters[currIndex];
                                currIndex++;
                            }
                        }
                    }

                    currIndex++;

                    if (!DiqOut.ContainsKey(denominator))
                    {
                        DiqOut.Add(denominator, description);
                    }

                    if (characters[currIndex] == '}')
                    {
                        isdonereading = true;
                    }
                    description = "";
                    denominator = "";
                    currIndex++;
                    if (currIndex == characters.Length)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }

        public static List<char> AllowedChars_English = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            
        public static bool ValidateWord(string word, List<char> allowedChars)
        {
            char[] chars = word.ToCharArray();
            foreach (var c in chars)
            {
                if (!allowedChars.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
