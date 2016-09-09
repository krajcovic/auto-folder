﻿using System;
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


            Parser parser = new Parser();
            Reakce reakce = new Reakce();

            string keyWord = "Table";
            string keyWord1 = "Dealt";
            string keyWord2 = "PokerStars";
            string keyWord3 = "FLOP";
            string keyWordend = "SUMMARY";
            const string STR_NAME_OF_TABLE = "Jmeno stolu";
            const string DEALT_TO = "Rozdano";
            const string TIME = "Cas";
            const string NUM_OF_HAND = "Cislo hry";
            const string FLOP = "Rozdano na flopu";

            // Ctenni souboru line by line
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Text.txt");
                foreach (string line in lines)
                {
                    if (line.Contains(keyWord)) // Jmeno stolu
                    {

                        var LineOfTable = Parser.getNameOfTable(line, keyWord);
                        int startIndex = LineOfTable.IndexOf(" '") + " '".Length;
                        int endIndex = LineOfTable.IndexOf("' ");
                        string jmenoStoluString = LineOfTable.Substring(startIndex, endIndex - startIndex);
                        Console.WriteLine(STR_NAME_OF_TABLE + ":" + jmenoStoluString);

                    }
                    if (line.Contains(keyWord1)) // Rozdane karty
                    {
                        var hand = Parser.getNameOfTable(line, keyWord1);
                        int startIndex = hand.IndexOf("[") + "[".Length;
                        int endIndex = hand.IndexOf("]");
                        /*musim prevest "hodnota + barva" a "hodnota + barva" na jednoduzsi format "hodnota, hodnota + barva shodna ano/ne"
                        melo by to vypadat treba   AKo = "Eso Kral offsuite"    QTs = "Dama Deset suite"       tim se snizi pocet kombynaci na 169 */
                        string dealtCardString = hand.Substring(startIndex, endIndex - startIndex);
                        //tady delim zapis na jednotlive karty    "prvniRozdana" a "druhaRozdana"
                        string prvnikarta = (".x" + dealtCardString + "x.");
                        int controlIndexA = prvnikarta.IndexOf(".x") + ".x".Length;
                        int controlIndexB = prvnikarta.IndexOf(" ");
                        string prvniRozdana = prvnikarta.Substring(controlIndexA, controlIndexB - controlIndexA);
                        int controlIndexA2 = prvnikarta.IndexOf(prvniRozdana) + prvniRozdana.Length;
                        int controlIndexB2 = prvnikarta.IndexOf("x.");
                        string druhaRozdana = prvnikarta.Substring(controlIndexA2, controlIndexB2 - controlIndexA2);

                        // tady zjistuju hodnotu a barvu prvni karty
                        string h1 = (prvniRozdana);
                        var hodnotaPrvniKarty = (h1[0]);
                        string b1 = (prvniRozdana);
                        var barvaPrvniKarty = (b1[1]);
                        //hodnota a barva druhe karty
                        string h2 = (druhaRozdana);
                        var hodnotaDruheKarty = (h2[1]);
                        string b2 = (druhaRozdana);
                        var barvaDruheKarty = (b2[2]);

                        // tady uz to kontroluje shodu barvy, bud je vysledek "s" nebo "o"
                        if (barvaPrvniKarty.Equals(barvaDruheKarty))
                        {
                            Console.WriteLine(DEALT_TO + "///" + hodnotaPrvniKarty + barvaPrvniKarty + hodnotaDruheKarty + barvaDruheKarty + "... Prevedeno na :" + hodnotaPrvniKarty + hodnotaDruheKarty + "s");
                        }
                        else
                        {
                            Console.WriteLine(DEALT_TO + "///" + hodnotaPrvniKarty + barvaPrvniKarty + hodnotaDruheKarty + barvaDruheKarty + "... Prevedeno na :" + hodnotaPrvniKarty + hodnotaDruheKarty + "o");
                        }

                        /* tady nevim jak to co mi vypsala konzole dostat do "string rozdaneKarty = hodnotaPrvniKarty + hodnotaDruheKarty + s/o" 
                         * abych stim mohl dal pracovat. ten vypsany vysledek neni objekt. aspom pro me ted neni objekt, mozna ze az to 
                         * pochopim tak zjistim ze je to objekt jak vino.   :)   
                         *
                         * Potrebuju to dostat do formatu "var nejakejmeno = ( hodnotaPrvniKarty + hodnotaDruheKarty + "vysledek srovnani (IF/ELSE = s/o)") 
                         * Potrebuju nakopnout, protoze nevim jak definovat ty vysledky. 
                         */
                        // krize  == k
                        // srdce  == h
                        // piky   == p
                        // kary   == d


                    }




                    if (line.Contains(keyWord2)) // Cas 
                    {
                        var time = Parser.getNameOfTable(line, keyWord2);
                        int startIndex = time.IndexOf("-") + "-".Length;
                        int endIndex = time.IndexOf("ET");
                        string timeString = time.Substring(startIndex, endIndex - startIndex);
                        Console.WriteLine(TIME + ":" + timeString);
                    }
                    if (line.Contains(keyWord2)) // Cislo hry
                    {
                        var num = Parser.getNameOfTable(line, keyWord2);
                        int startIndex = num.IndexOf("Hand #") + "Hand #".Length;
                        int endIndex = num.IndexOf(":");
                        string numString = num.Substring(startIndex, endIndex - startIndex);
                        Console.WriteLine(NUM_OF_HAND + ":" + numString);
                    }
                    if (line.Contains(keyWord3)) // Rozdano na flopu  >>> Mozna do budoucna pouziju na druhy krok ve hre (nejaka reakce na flop)                            
                    {
                        var flop = Parser.getNameOfTable(line, keyWord3);
                        int startIndex = flop.IndexOf("[") + "[".Length;
                        int endIndex = flop.IndexOf("]");
                        string flopString = flop.Substring(startIndex, endIndex - startIndex);
                        Console.WriteLine(FLOP + ":" + flopString);
                    }
                    if (line.Contains(keyWordend)) // Posledni radek jedne hry, tohle bude definovad bod zapisuj do array radku +1
                    {                              // To jeste musim pospekulovat jak to udelat
                        var end = Parser.getNameOfTable(line, keyWordend);
                        int startIndex = end.IndexOf("S") + "S".Length;
                        int endIndex = end.IndexOf("Y");
                        string endString = end.Substring(startIndex, endIndex - startIndex);
                        Console.WriteLine("........................................................................");
                    }
                    /*else
                    {
                        // Jestlize ho nenajde, tak 
                        Console.WriteLine(".");
                    }
                    */
                }
            }
            catch (Exception e)
            {
                // Co budes delat, kdyz ten soubor neexistuje?   
                // Tohle budu resit az ta aplikace bude v okne, myslim tem bude texbox kde se budou vypysovat chyby
                // Tech chyb muze byt kopa, takto tam necham vypisovat vsechno
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press ENTER for finish.");
            Console.ReadLine();
        }
    }

    class Reakce
    {
        /* Tady nacist soubor se sadou hranych/nehranych kombinaci. Mam na to zalozit samostatnou tridu
        *  viz "class Reakce" a resit to vni nebo to mamjeste vepsat do te tridy nahore "class program"
        *  vubec nemam zdani jak v tom udelat nejaky system. mam pocit ze je to strasne neprehledne.
        *  I ta pasaz "Rozdane karty" je to neprehledny flak textu. Jak je to s otdsazovanim a nejakyma 
        *  pravidlama kolem upravy aby se v tom dalo trochu vyznat. Cely ten kod ma cca 170 radku, neumim 
        *  si predstavit kdy u Vas pisete nejaky slozity megazdrojak a musi se v tom orientovat nekolik 
        *  lidi kteri na tom spolupracujou  
        */

    }

}