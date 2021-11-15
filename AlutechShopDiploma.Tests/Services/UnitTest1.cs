using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlutechShopDiploma.Tests.Services
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AlutechShopDiploma.Services.GoodWorker goodWorker = new AlutechShopDiploma.Services.GoodWorker(44);
            string name = goodWorker.GetGoodName();
            string expName = "Комплект для автоматизации откатных ворот ASL500KIT";
            Assert.AreEqual(name, expName);
        }
    }
}
