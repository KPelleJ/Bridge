using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServers
{
    /// <summary>
    /// Holds information of a math operation "method" and the two values involved in this operation
    /// </summary>
    public class JsonRequest
    {
        public string Method { get; set; }
        public int? Value1 { get; set; }
        public int? Value2 { get; set; }
    }
}
