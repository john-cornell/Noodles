using System;
using System.Linq;
using System.Net;
using Noodles.Data.Projections;

namespace Noodles.Data
{
    public static class DataTableUrlLoader
    {
        ///
        public static void LoadData(DataTable dataTable, string url, bool firstRowIsHeader, bool testForNumeric = true)
        {
            Func<string, object> parser = null;

            if (testForNumeric)
                parser = GetDataNumericTest;
            else
                parser = CastToObject;

            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(url);

                string[] rows = data.Split(new string[] { Environment.NewLine, '\r'.ToString(), '\n'.ToString() }, StringSplitOptions.RemoveEmptyEntries);

                if (firstRowIsHeader)
                {
                    dataTable.Headers = rows[0].Split(',').Select(s => s.Trim()).ToList();
                }

                foreach (string row in rows.Skip(firstRowIsHeader ? 1 : 0))
                {
                    dataTable.Add(row.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => parser(s.Trim())));
                }
            }
        }

        private static object CastToObject(string item) => (object)item;

        private static object GetDataNumericTest(string item)
        {
            if (double.TryParse(item, out double number))
            {
                return number;
            }

            return item;
        }
    }
}
