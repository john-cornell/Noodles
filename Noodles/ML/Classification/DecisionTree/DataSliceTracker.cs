using Noodles.Data.Projections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.ML.Classification.DecisionTree
{
    public class DataSliceTracker : IEnumerable<int>
    {
        public enum Slice
        { Column, Row }

        private readonly HashSet<int> _slices;
        private readonly HashSet<int> _removed;

        public Slice SliceType { get; private set; }

        public DataSliceTracker(DataTable table, Slice sliceType) :
            this(Enumerable.Range(0, sliceType == Slice.Column ? table.ColumnCount : table.RowCount))
        {
            SliceType = sliceType;
        }

        private DataSliceTracker(IEnumerable<int> slices)
        {
            _slices = new HashSet<int>(slices);
            _removed = new HashSet<int>();
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