using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMachine.Core.Test
{
    /// <summary>
    ///     Test Utilities Module
    ///     {CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C
    /// </summary>
    [TestClass]
    public class AngleTest
    {
        /// <summary>
        ///     Test Angle Create
        /// </summary>
        [TestMethod]
        public void TestAngleCreate()
        {
            var angle = new Angle(0);
            Assert.IsTrue(Utilities.DoubleEqual(angle.Radians, 0));
            Assert.IsTrue(Utilities.DoubleEqual(angle.Degrees, 0));

            angle = new Angle(2.0*Math.PI);
            Assert.IsTrue(Utilities.DoubleEqual(angle.Radians, 0));
            Assert.IsTrue(Utilities.DoubleEqual(angle.Degrees, 0));

            angle = new Angle(Math.PI*3);
            Assert.IsTrue(Utilities.DoubleEqual(angle.Radians, Math.PI));
            Assert.IsTrue(Utilities.DoubleEqual(angle.Degrees, 180));

            angle = new Angle(-Math.PI);
            Assert.IsTrue(Utilities.DoubleEqual(angle.Radians, Math.PI));
            Assert.IsTrue(Utilities.DoubleEqual(angle.Degrees, 180));

            angle = new Angle(-2.0*Math.PI);
            Assert.IsTrue(Utilities.DoubleEqual(angle.Radians, 0));
            Assert.IsTrue(Utilities.DoubleEqual(angle.Degrees, 0));

            angle = new Angle(-Math.PI*3);
            Assert.IsTrue(Utilities.DoubleEqual(angle.Radians, Math.PI));
            Assert.IsTrue(Utilities.DoubleEqual(angle.Degrees, 180));
        }

        /// <summary>
        ///     Tests the angle ComparTo, and Equality/Inequality operators.
        /// </summary>
        [TestMethod]
        public void TestAngleCompare()
        {
            const int count = 256;

            var angles =
                Enumerable.Range(0, count)
                    .Select(
                        value => (new Angle(2*Math.PI/count*value)) as IComparable)
                    .ToArray();

            for (var i = 0; i < count; i++)
            {
                // ReSharper disable once EqualExpressionComparison
                Assert.IsTrue(angles[i].Equals(angles[i]));
                // ReSharper disable once EqualExpressionComparison
                Assert.IsTrue((Angle) angles[i] == (Angle) angles[i]);

                Assert.IsTrue(angles[i].CompareTo(angles[(i + count/2)%count]) < 0);

                for (var j = 1; j < count/2; j++)
                {
                    var greater = (i + j)%count;
                    var less = (i + j + count/2)%count;

                    Assert.IsFalse((Angle) angles[i] ==
                                   (Angle) angles[less]);

                    Assert.IsFalse((Angle) angles[i] ==
                                   (Angle) angles[greater]);

                    Assert.IsTrue(angles[i].CompareTo(angles[greater]) < 0);

                    Assert.IsTrue((Angle) angles[i] <
                                  (Angle) angles[greater]);
                    Assert.IsTrue((Angle) angles[i] <=
                                  (Angle) angles[greater]);

                    Assert.IsFalse((Angle) angles[i] >
                                   (Angle) angles[greater]);
                    Assert.IsFalse((Angle) angles[i] >=
                                   (Angle) angles[greater]);

                    Assert.IsTrue(angles[i].CompareTo(angles[less]) > 0);

                    Assert.IsTrue((Angle) angles[i] >
                                  (Angle) angles[less]);

                    Assert.IsTrue((Angle) angles[i] >=
                                  (Angle) angles[less]);

                    Assert.IsFalse((Angle) angles[i] <
                                   (Angle) angles[less]);

                    Assert.IsFalse((Angle) angles[i] <=
                                   (Angle) angles[less]);
                }
            }

            // Test extremes
            IComparable angleIc1 = new Angle(0);
            IComparable angleIc2 = new Angle(Math.PI);

            Assert.IsTrue(angleIc1.CompareTo(angleIc2) < 0);
            Assert.IsTrue(angleIc2.CompareTo(angleIc1) < 0);

            var angle1 = new Angle(0);
            var angle2 = new Angle(Math.PI);

            Assert.IsTrue(angle1 < angle2);
            Assert.IsTrue(angle1 <= angle2);
            Assert.IsFalse(angle1 > angle2);
            Assert.IsFalse(angle1 >= angle2);

            Assert.IsTrue(angle2 < angle1);
            Assert.IsTrue(angle2 <= angle1);
            Assert.IsFalse(angle2 > angle1);
            Assert.IsFalse(angle2 >= angle1);
        }

        /// <summary>
        ///     Test angle operators (+,-,*)
        /// </summary>
        [TestMethod]
        public void TestAngleOperators()
        {
            
        }
    }
}