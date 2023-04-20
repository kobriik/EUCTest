using Microsoft.VisualStudio.TestTools.UnitTesting;
using EUCTest.Models;
using System;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(EucDatabaseContext d = new EucDatabaseContext())
            {

            }
        }
    }
}
