using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServers
{
    public class JsonRequest
    {
        public string Method { get; set; }
        public int? Value1 { get; set; }
        public int? Value2 { get; set; }
    }
}
