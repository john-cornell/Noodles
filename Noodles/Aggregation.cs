using Noodles.AggregationProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noodles
{
    public static class Aggregation
    {
        static Aggregation()
        {
            Means = new Mean();
            Properties = new Properties();
        }

        public static Mean Means { get; set; }
        public static Properties Properties;
    }
}
