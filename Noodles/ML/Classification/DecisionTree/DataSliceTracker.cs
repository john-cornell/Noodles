using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;

namespace Noodles.ML.Classification.DecisionTree
{
    public class DataSliceTracker : IEnumerable<int>
    {
        public enum Slice { Column, Row }

        readonly HashSet<int> _slices;
        readonly HashSet<int> _removed;

        public Slice SliceType { get; private set; }

        public DataSliceTracker(DataTable table, Slice sliceType) :
            this(Enumerable.Range(0, sliceType == Slice.Column ? table.ColumnCount : table.RowCount))
        {
            SliceType = sliceType;
        }

        public DataSliceTracker(IEnumerable<int> slices)
        {
            _slices = new HashSet<int>(slices);
        }

        public DataSliceTracker Clone()
        {
            return new DataSliceTracker(_slices);
        }

        public DataSliceTracker CloneNegative()
        {
            return new DataSliceTracker(_removed);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _slices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void RemoveItem(int item)
        {
            _slices.Remove(item);
            _removed.Add(item);
        }
    }
}
