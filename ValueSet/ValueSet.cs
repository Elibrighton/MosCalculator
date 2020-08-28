using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueSetInterface;

namespace ValueSet
{
    public class ValueSet : IValueSet
    {
        public bool HasValue { get; set; }
        public double Value { get; set; }
    }
}
