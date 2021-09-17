﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingServiceApp.Application.DTO.Response
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
    }
}
