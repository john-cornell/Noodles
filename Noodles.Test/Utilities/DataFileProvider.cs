using System;

namespace Noodles.Test.Utilities
{
    public class DataFileProvider
    {
        public enum FileDataType
        {
            Decimal = 1 << 0
        }

        public string RandomFileName { get => string.Format(@"{0}.txt", Guid.NewGuid()); }

        private string GenerateData(int columns, int rows, params FileDataType[] dataTypes)
        {
            string fileName = RandomFileName;

            return fileName;
        }

        public const string DiabetesCsv = @"https://raw.githubusercontent.com/john-cornell/noodles-data/main/diabetes.csv";
    }
}
