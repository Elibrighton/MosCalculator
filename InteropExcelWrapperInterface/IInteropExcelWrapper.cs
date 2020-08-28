using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteropExcelWrapperInterface
{
    public interface IInteropExcelWrapper
    {
        Application Application { get; set; }
        Workbook Workbook { get; set; }

        void OpenSpreadsheet();
        void OpenWorkBook();
        void OpenWorkSheet(int index);
        void FindLastRow();
        void FindLastColumn();
        void FindStartRange(int row, int column);
        void FindEndRange();
        void LoadRange();
    }
}
