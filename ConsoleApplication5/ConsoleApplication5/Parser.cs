using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Parser
    {
             // tady mel a byt funkce ktera dosadi do "string jmeno" nazev stolu.
            public static string getNameOfTable(string line, string keyWord)
            {
                return line.Substring(line.IndexOf(keyWord));
            }

        public static string getNameOfTable2(string line, string keyWord)
        {
            int pos = line.IndexOf(keyWord);
            if (pos != -1)
            {
                // tak jsem to slovo nasel
                Debug.Write(line.Substring(pos));

                // Reseni je samozrejme spousta, me treba jako prvni napada rozdelit to podle slov
                string subLine = line.Substring(pos);
                string[] splitWords = subLine.Split(' ');

                // No a ja prece vim, ze subLine obsahuje urcite jako prvni to moje slovo a hned za nim je to slovo ktere hledam
                return splitWords[1];

            } else
            {
                // klicove slovo jsem nenasel, musis cist dokumentaci
                return null;
            }
        }
    }
}
