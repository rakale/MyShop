using Abc.Aids.Extensions;
using System.Collections.Generic;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Abc.Aids.Services {

    public sealed class ExcelInteroperability {
        private string[] columnNames;

        public string FileName { get; }

        public bool ColumnNamesInFirstRow { get; }

        public ExcelInteroperability(string fileName, bool columnNamesInFirstRow) {
            FileName = fileName;
            ColumnNamesInFirstRow = columnNamesInFirstRow;
        }

        public List<T> Read<T>(List<ExcelRowClassMapper> mapper) where T : class, new() {
            var l = new List<T>();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp?.Workbooks.Open(FileName);
            Excel._Worksheet xlWorksheet = (Excel._Worksheet)(xlWorkbook?.Sheets[1]);
            Excel.Range xlRange = xlWorksheet?.UsedRange;

            int rowCount = xlRange?.Rows.Count ?? 0;
            int colCount = xlRange?.Columns.Count ?? 0;

            T item = null;

            for (int i = 1; i <= rowCount; i++) {
                if (i == 1 && ColumnNamesInFirstRow) readColumnNames(xlRange, colCount);

                else for (int j = 1; j <= colCount; j++) {
                        if (j == 1) {
                            item = new T();
                            setCommonValues(item, mapper);
                        }
                        var cell = xlRange.Cells[i, j] as Excel.Range;
                        var value = cell?.Value;
                        var propertyName = getPropertyName(mapper, j);
                        var property = typeof(T).GetProperty(propertyName);
                        if (value != null) setValue(item, property, value);
                    }
                if (!(item is null)) l.Add(item);
            }

            xlWorkbook?.Close();
            xlApp?.Quit();

            return l;
        }

        private string getPropertyName(List<ExcelRowClassMapper> mapper, int columnIndex) {
            foreach (var e in mapper) {
                if (e.ValueType != ExcelRowClassMapperType.ColumnIndex) continue;
                if (e.Value.ToString() == columnIndex.ToString()) return e.Name;
            }
            if (columnNames == null) return string.Empty;
            var columnName = columnNames[columnIndex - 1];
            foreach (var e in mapper) {
                if (e.ValueType != ExcelRowClassMapperType.ColumnName) continue;
                if (e.Value.ToString() == columnName) return e.Name;
            }
            return string.Empty;
        }

        internal void setValue<T>(T item, PropertyInfo p, object value) where T : class, new() {
            var v = Variable.TryParse(value.ToString(), p?.PropertyType);
            if (p?.CanWrite ?? false) p?.SetValue(item, v);
        }

        internal void setCommonValues<T>(T item, List<ExcelRowClassMapper> mapper) where T : class, new() {
            foreach (var e in mapper) setCommonValue(item, e);
        }

        internal void setCommonValue<T>(T item, ExcelRowClassMapper e) where T : class, new() {
            if (e.ValueType != ExcelRowClassMapperType.Value) return;
            var pi = getPropertyInfo(item, e.Name);
            setValue(item, pi, e.Value);
        }

        internal PropertyInfo getPropertyInfo<T>(T item, string name) where T : class, new() => item?.GetType().GetProperty(name);

        private void readColumnNames(Excel.Range xlRange, int colCount) {
            columnNames = new string[colCount + 1];
            for (int j = 1; j <= colCount; j++) {
                var cell = xlRange.Cells[1, j] as Excel.Range;
                var value = cell?.Value2;
                columnNames[j - 1] = value?.ToString();
            }
        }
    }

}
