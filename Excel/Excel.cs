using ExcelInterface;
using InteropExcelWrapperInterface;
using System;
using System.IO;
using WebInterface;

namespace Excel
{
    public class Excel : IExcel
    {
        public IWeb Web { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public bool IsDownloaded { get; set; }
        public IInteropExcelWrapper InteropExcelWrapper { get; set; }

        public Excel(IWeb web, IInteropExcelWrapper interopExcelWrapper)
        {
            Web = web;
            InteropExcelWrapper = interopExcelWrapper;
        }

        public void WriteFile(Stream stream)
        {
            using (var memoryStream = stream)
            {
                using (var fileStream = File.Create(Path))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }

        public void DownloadUrl(string url)
        {
            Web.RequestUrl(url);

            if (!string.IsNullOrEmpty(Web.Response))
            {
                WriteFile(Web.Stream);
            }
        }

        public void CheckIfDownloaded()
        {
            if (!string.IsNullOrEmpty(Path))
            {
                IsDownloaded = File.Exists(Path);
            }
        }

        public void DeleteExisting()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }

        public void LoadRange(int firstRow, int firstColumn)
        {
            InteropExcelWrapper.OpenSpreadsheet();
            InteropExcelWrapper.OpenWorkBook();
            InteropExcelWrapper.OpenWorkSheet(1);
            InteropExcelWrapper.FindLastRow();
            InteropExcelWrapper.FindLastColumn();
            InteropExcelWrapper.FindStartRange(4, 1);
            InteropExcelWrapper.FindEndRange();
            InteropExcelWrapper.LoadRange();
        }
    }
}
