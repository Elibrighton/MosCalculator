using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExcelInterface
{
    public interface IExcel
    {
        string Path { get; set; }

        void WriteFile(Stream stream);
        void DownloadUrl(string url);
        bool IsDownloaded { get; set; }
        void CheckIfDownloaded();
        void DeleteExisting();
        void LoadRange(int firstRow, int firstColumn);
    }
}
