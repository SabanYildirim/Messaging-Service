using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Common.Results
{
    public interface IMessagingException
    {
        public int StatusCode { get; set; }
    }
}
