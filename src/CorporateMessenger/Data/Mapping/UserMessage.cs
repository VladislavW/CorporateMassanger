using CorporateMessenger.Data.Mapping;

namespace CorporateMassenger.Data.Mapping
{
    public sealed class UserMessage : BaseEntity<int>
    {
        public int? UserId { get; set; }
        public int? MessageId { get; set; }
        public User User { get; set; }
        public Message Message { get; set; }
    }
}