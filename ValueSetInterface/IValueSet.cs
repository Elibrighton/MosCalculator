using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueSetInterface
{
    public interface IValueSet
    {
        bool HasValue { get; set; }
        double Value { get; set; }
    }
}
