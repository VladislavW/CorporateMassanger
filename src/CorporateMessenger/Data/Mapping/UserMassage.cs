using CorporateMessenger.Data.Mapping;

namespace CorporateMassenger.Data.Mapping
{
    public sealed class UserMassage : BaseEntity<int>
    {
        public int? UserId { get; set; }
        public int? MassageId { get; set; }
        public User User { get; set; }
        public Massage Massage { get; set; }
    }
}