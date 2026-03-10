
using System.Data;
using ExcelDataReader;

namespace ProjectUtilityExcel
{
    public static class ExcelReaderUtil
    {

        public static System.Data.DataTable ExcelToDataTable(string filename, string? sheetName, bool useHeaderRow = true)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename is required.", nameof(filename));

            if (!File.Exists(filename))
                throw new FileNotFoundException("Excel file not found.", filename);


            using var stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = useHeaderRow
                }
            };

            using var resultSet = reader.AsDataSet(conf);
            var tables = resultSet.Tables;

            System.Data.DataTable? table = null;

            if (!string.IsNullOrWhiteSpace(sheetName) && tables.Contains(sheetName))
            {
                table = tables[sheetName!];
            }
            else if (tables.Count > 0)
            {
                table = tables[0];
            }

            if (table == null)
                throw new ArgumentException($"The worksheet '{sheetName}' does not exist and no fallback sheet was found.", nameof(sheetName));

            return table;
        }


        public sealed class DataCell
        {
            public required int RowNumber { get; init; }
            public required string ColumnName { get; init; }
            public required string Value { get; init; }
        }

        private static readonly List<DataCell> _dataCache = new();

        public static void PopulateInCollection(string filename, string? sheetName, bool useHeaderRow = true)
        {
            var table = ExcelToDataTable(filename, sheetName, useHeaderRow);

            _dataCache.Clear();

            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    var cell = new DataCell
                    {
                        RowNumber = row + 1,
                        ColumnName = table.Columns[col].ColumnName,
                        Value = table.Rows[row][col]?.ToString() ?? string.Empty
                    };

                    _dataCache.Add(cell);
                }
            }
        }

        public static string? ReadData(int rowNumber, string columnName)
        {
            if (rowNumber <= 0 || string.IsNullOrWhiteSpace(columnName))
                return null;


            var data = _dataCache.FirstOrDefault(c =>
                c.RowNumber == rowNumber &&
                string.Equals(c.ColumnName, columnName, StringComparison.OrdinalIgnoreCase));

            return data?.Value;
        }
    }
}
