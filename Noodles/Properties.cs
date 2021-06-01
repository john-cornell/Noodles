using System;
using System.Collections.Generic;
using System.Text;

namespace Noodles.AggregationProperties
{
    public class Properties
    {
        public Properties()
        {
            Symmetry = new SymmetryAggregationProperty();
        }

        public SymmetryAggregationProperty Symmetry { get; private set; }
    }
}
