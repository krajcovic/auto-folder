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
            Slovník slovník = new Slovník();         //tohle mam jenom vycleneny prostor pro nejakou 
                                                     //funkci na zjisteni jmena (je v tom textu hned za slovem "Table")
            string text = "table";
            var JmenoStolu = "";                     //tohle by se pozdeji melo vyplnit 
            var a = "Jmeno stolu";                   //tohle se vypise pred 

            // Ctenni souboru line by line
            string[] lines = System.IO.File.ReadAllLines("c:\\text.txt");
            foreach (string line in lines)
            {
                if (text != "table")                 //nenajde hledane slovo "table"
                {                                    //vypise chybu "chyba"
                    Console.WriteLine("chyba");
                    break;
                }
                else
                {
                    Console.WriteLine(a + JmenoStolu);//tady to melo vipsat var a "Table Name" + jmeno toho stolu
                }
            } while (text != null) ;


            Console.ReadLine();
        }
    }
    class Slovník
    {
        // tady mel a byt funkce ktera dosadi do "string jmeno" nazev stolu.
    }
}
