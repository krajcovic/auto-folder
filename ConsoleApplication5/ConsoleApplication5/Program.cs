using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Spatny pocet parametru, zadej nazev souboru, ktery chces prohledavat");
                return;
            }

            Parser parser = new Parser();                                     
                                                     
            string keyWord = "table";
            const string STR_NAME_OF_TABLE = "Jmeno stolu";                   // Tohle je konstanta, nikdy se nezmeni, tak ji taky tak deklaruj

            // Ctenni souboru line by line
            try
            {
                string[] lines = System.IO.File.ReadAllLines(args[0]);
                foreach (string line in lines)
                {
                    if (line.Contains(keyWord)) // Zjisti jestli line obsahuje klicove slovo(table)
                    {
                        // TODO: Tady si najdu teda jmeno stolu, protoze uz vim 
                        var nameOfTable = Parser.getNameOfTable(line, keyWord);
                        Console.WriteLine(STR_NAME_OF_TABLE + " : " +  nameOfTable); //tady to melo vipsat var a "Table Name" + jmeno toho stolu

                    }
                    else
                    {
                        // Jestlize ho nenajde, tak 
                        Console.WriteLine("Tohle rozhodne neni hledany radek: " + line);
                    }
                }
            } catch (Exception e)
            {
                // Co budes delat, kdyz ten soubor neexistuje?
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press ENTER for finish.");
            Console.ReadLine();
        }
    }

    /*
    Jestli te jeste jednou uvidim, ze si pojmenoval jakykoliv objekt s ceskou diakritikou (hacky, carky) tak
    normalne dojedu a nakopu te, tam kam slunce nesviti.
    */
    class Parser
    {
        // tady mel a byt funkce ktera dosadi do "string jmeno" nazev stolu.
        internal static string getNameOfTable(string line, string keyWord)
        {
            return line.Substring(line.IndexOf(keyWord));
        }
    }
}
