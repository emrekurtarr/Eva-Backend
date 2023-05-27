using SuperTraders.Entities.Base;

namespace SuperTraders.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
