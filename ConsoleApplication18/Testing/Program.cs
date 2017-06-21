using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MironsUtilBox;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> TesterDiq;
            if (ParseUtils.Diqtionary(@"../dictionary.json.txt", out TesterDiq))
            {
                try
                {

               
                Console.WriteLine(TesterDiq.Keys.ElementAt(1000).ToString());
                Console.WriteLine(TesterDiq.Keys.ElementAt(100).ToString());
                Console.WriteLine(TesterDiq.Keys.ElementAt(100).ToString());
                Console.WriteLine(TesterDiq.Keys.ElementAt(TesterDiq.Count-1).ToString());
                Console.ReadLine();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Something don gone fucked up son.");
                Console.ReadLine();
            }
        }
    }
}
