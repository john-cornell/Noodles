using System;
using System.Collections.Generic;
using System.Text;

namespace Noodles
{
    public static class Calculator
    {
        static Calculator()
        {
            Means = new Mean();
        }

        public static Mean Means { get; private set; }
    }
}
