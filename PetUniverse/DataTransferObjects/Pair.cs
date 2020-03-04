using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class Pair<T1, T2>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }
    }
}
