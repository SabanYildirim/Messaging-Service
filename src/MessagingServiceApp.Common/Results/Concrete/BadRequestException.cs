using MessagingServiceApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace MessagingServiceApp.Common.Results.Concrete
{
    public class BadRequestException : Exception, IMessagingException
        {
            /// <summary>
            /// Status Code
            /// </summary>
            public int StatusCode { get; set; }

            /// <summary>
            /// ctor
            /// </summary>
            public BadRequestException()
            {
                StatusCode = StatusCodes.Status400BadRequest;
            }

            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="message"></param>
            public BadRequestException(string message) : base(message)
            {
                StatusCode = StatusCodes.Status400BadRequest;
            }

            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="message"></param>
            /// <param name="exception"></param>
            public BadRequestException(string message, Exception exception) : base(message, exception)
            {
                StatusCode = StatusCodes.Status400BadRequest;
            }
        }
}
