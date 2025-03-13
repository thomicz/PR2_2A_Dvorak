using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04_UnitTesting_01_Minimum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_UnitTesting_01_Minimum.Tests
{
    [TestClass()]
    public class ToolsTests
    {
        [TestMethod()]
        [ExpectedException (typeof(ArgumentException))]
        public void FindMinEmpySetTest()
        {
            int[] nums = [];
            Tools.FindMin(nums);
            Assert.Fail();
        }
    }
}