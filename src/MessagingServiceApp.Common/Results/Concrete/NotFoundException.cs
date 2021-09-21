using MessagingServiceApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace MessagingServiceApp.Common.Results.Concrete
{
    public class NotFoundException : Exception, IMessagingException
        {
            /// <summary>
            /// Status Code
            /// </summary>
            public int StatusCode { get; set; }

            /// <summary>
            /// ctor
            /// </summary>
            public NotFoundException()
            {
                StatusCode = StatusCodes.Status404NotFound;
            }

            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="message"></param>
            public NotFoundException(string message) : base(message)
            {
                StatusCode = StatusCodes.Status404NotFound;
            }

            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="message"></param>
            /// <param name="exception"></param>
            public NotFoundException(string message, Exception exception) : base(message, exception)
            {
                StatusCode = StatusCodes.Status404NotFound;
            }
        }
}
