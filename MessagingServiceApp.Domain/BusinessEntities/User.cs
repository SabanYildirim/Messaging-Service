using MessagingServiceApp.Domain.BusinessEntities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingServiceApp.Domain.BusinessEntities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Password { get; set; }
    }
}
