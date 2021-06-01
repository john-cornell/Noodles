using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Noodles.Test.ExtensionTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]


    public class IEnumberableExtensionsTests
    {
        [TestMethod]
        public void WhenCycleCalled_ValuesShouldBeCorrect()
        {
            int[] input = new int[] { 0, 1, 2, 3, 4, 5 };
            IEnumerable<IEnumerable<int>> expected = new List<IEnumerable<int>>
            {
                new int[] { 0, 1, 2, 3, 4, 5 }.AsEnumerable(),
                new int[] { 1, 2, 3, 4, 5, 0 }.AsEnumerable(),
                new int[] { 2, 3, 4, 5, 0, 1 }.AsEnumerable(),
                new int[] { 3, 4, 5, 0, 1, 2 }.AsEnumerable(),
                new int[] { 4, 5, 0, 1, 2, 3 }.AsEnumerable(),
                new int[] { 5, 0, 1, 2, 3, 4 }.AsEnumerable()
            };

            List<IEnumerable<int>> actual = input.Cycle().ToList();

            Assert.AreEqual(input.Count(), actual.Count());

            for (int i = 0; i < actual.Count; i++)
            {
                IEnumerable<int> innerActual = actual.ElementAt(i);
                IEnumerable<int> innerExpected = expected.ElementAt(i);

                Assert.AreEqual(innerActual.Count(), innerExpected.Count());

                for (int j = 0; j < innerActual.Count(); j++)
                    Assert.AreEqual(innerActual.ElementAt(j), innerExpected.ElementAt(j));
            }
        }
    }
}
