using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServers
{
    /// <summary>
    /// Contains error information regarding the client request to be shown to the client.
    /// </summary>
    public class JsonErrorMessage
    {
        public string ErrorType { get; set; }
        public string Message { get; set; }

        public JsonErrorMessage(string errorType, string message)
        {
            ErrorType = errorType;
            Message = message;
        }
    }
}
