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
            var t = new HashTable.HashTable(3);

            t.Insert("dd", 231);
            t.Insert("dfg", 3224);
            t.Insert("aaas", 4422);

            Assert.AreEqual(t.GetValueByKey("dd"), 231);
            Assert.AreEqual(t.GetValueByKey("dfg"), 3224);
            Assert.AreEqual(t.GetValueByKey("aaas"), 4422);
        }
    }
}
