using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication5;

namespace UnitTestApplication5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParsingTable()
        {
            // Puvodni verze
            String actual = Parser.getNameOfTable("Toto je muj testovaci string. a hledam nazev stolu: STUL21. Za tim stolem muze byt spousta zbytecneho balastu", "stolu:");
            String expected = "stolu: STUL21. Za tim stolem muze byt spousta zbytecneho balastu";

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestParsingTable2()
        {
            // Ja si to ovsem upravim tak, aby mi to vracelo pouze to slovo testovaci
            String actual = Parser.getNameOfTable2("Toto je muj testovaci string. a hledam nazev stolu: STUL21. Za tim stolem muze byt spousta zbytecneho balastu", "stolu:");
            String expected = "STUL21.";

            Assert.AreEqual(expected, actual);

        }
    }
}
