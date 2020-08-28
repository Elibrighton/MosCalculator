using InteropExcelWrapperInterface;
using Microsoft.Office.Interop.Excel;
using System;

namespace InteropExcelWrapper
{
    public class InteropExcelWrapper : IInteropExcelWrapper
    {
        private string _path;
        private object _startRange;
        private object _endRange;

        public Application Application { get; set; }
        public Workbook Workbook { get; set; }
        public Worksheet Worksheet { get; set; }
        public int LastRow { get; set; }
        public int LastColumn { get; set; }
        public Range Range { get; set; }

        public InteropExcelWrapper(string path)
        {
            _path = path;
        }

        public void OpenSpreadsheet()
        {
            Application = new Application();
        }

        public void OpenWorkBook()
        {
            Workbook = Application.Workbooks.Open(_path);
        }

        public void OpenWorkSheet(int index)
        {
            Worksheet = (Worksheet)Workbook.Worksheets[index];
        }

        public void FindLastRow()
        {
            LastRow = Worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                              System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                              XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious,
                              false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
        }

        public void FindLastColumn()
        {
            LastColumn = Worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious,
                                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
        }

        public void FindStartRange(int row, int column)
        {
            _startRange = Worksheet.Cells[row, column];
        }

        public void FindEndRange()
        {
            _endRange = Worksheet.Cells[LastRow, LastColumn];
        }

        public void LoadRange()
        {
            Range = (Range)Worksheet.Range[_startRange, _endRange];
        }
    }
}
