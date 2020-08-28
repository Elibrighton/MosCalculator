using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInterface
{
    public interface IWeb
    {
        void ConvertStringToStream(string text);

        Stream Stream { get; set; }

        void RequestUrl(string url);

        string Response { get; set; }
    }
}
