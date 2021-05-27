using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noodles.Test
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void WhenMeansCalledOnCalculator_ShouldNotBeNull()
        {
            Assert.IsNotNull(Calculator.Means);
        }
    }
}
