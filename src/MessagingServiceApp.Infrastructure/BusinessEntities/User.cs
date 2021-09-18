using MessagingServiceApp.Infrastructure.BusinessEntities.Base;

namespace MessagingServiceApp.Infrastructure.BusinessEntities
{
    [BsonCollection("users")]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
