using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Common
{
    public class LoggerTemplates
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string BadRequest = $"BAD REQUEST: HTTP {"{" + nameof(LoggerModel.RequestMethod) + "}"} / {"{" + nameof(LoggerModel.RequestPathAndQuery) + "}"} responded as {"{" + nameof(LoggerModel.ResponseStatusCode) + "}"}";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string Error = $"ERROR: HTTP {"{" + nameof(LoggerModel.RequestMethod) + "}"} / {"{" + nameof(LoggerModel.RequestPathAndQuery) + "}"} responded as {"{" + nameof(LoggerModel.ResponseStatusCode) + "}"}";
    }
}
