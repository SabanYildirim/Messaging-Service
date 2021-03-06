using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Common
{
    public class LoggerModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string RequestHost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestProtocol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestPath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestPathAndQuery { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ResponseStatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> RequestHeaders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? ElapsedMilliseconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InnerException { get; set; }
    }
}
