using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServers
{
    /// <summary>
    /// Stores information regarding a JsonRequest object and adds a result to the JsonRequests method and values
    /// </summary>
    public class JsonResponse
    {
        public string Method { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Result { get; set; }
    }
}
