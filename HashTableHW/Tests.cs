using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Compatibility;
using HashTable;
namespace Tests
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void ElementsTest()
        {
            var HashT = new HashTable.HashTable(3);

            HashT.PutPair("HI", 1337);
            HashT.PutPair("I`M", 1488);
            HashT.PutPair("OLDMEN", 228);

            Assert.AreEqual(HashT.GetValueByKey("HI"), 1337);
            Assert.AreEqual(HashT.GetValueByKey("I`M"), 1488);
            Assert.AreEqual(HashT.GetValueByKey("OLDMEN"), 228);
        }
        [Test]
        public void TwoEquialsElementsTest()
        {
            var HashT = new HashTable.HashTable(3);

            HashT.PutPair("a", 1);
            HashT.PutPair("a", 2);

            Assert.AreEqual(HashT.GetValueByKey("a"), 2);
        }

        [Test]
        public void Elements1000Test()
        {
            var HashT = new HashTable.HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                HashT.PutPair(i, i + 100);
            }
            Assert.AreEqual(HashT.GetValueByKey(15), 115);
        }

        [Test]
        public void ElementsSearchTests()
        {
            var h = new HashTable.HashTable(10000);

            for (int i = 0; i < 10000; i++)
            {
                h.PutPair(i, i + 1);
            }

            for (int i = 10000; i < 11000; i++)
            {
                Assert.AreEqual(h.GetValueByKey(i), null);
            }
        }
    }
}