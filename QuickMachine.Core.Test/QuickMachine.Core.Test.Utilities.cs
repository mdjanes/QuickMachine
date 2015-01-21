using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMachine.Core.Test
{
    /// <summary>
    ///     Test Utilities Module
    ///     {CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C
    /// </summary>
    [TestClass]
    public class UtilitiesTest
    {
        #region DoubleEqual

        /// <summary>
        ///     Tests the DoubleEqual method.
        /// </summary>
        [TestMethod]
        public void TestDoubleEqual()
        {
            var count = Math.Pow(2, 8);
            var inc = Utilities.EPSILON/count;

            for (var i = 0; i < count; i++)
                Assert.IsTrue(Utilities.DoubleEqual(0, inc*i));

            Assert.IsFalse(Utilities.DoubleEqual(0, inc + count + 1));
        }

        #endregion
    }
}