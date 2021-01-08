using HumbleBob.Dal.Entities.Enums;

namespace HumbleBob.Dal.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        public string Desciption { get; set; }

        public decimal Price { get; set; }

        public StorageUnit StorageUnit { get; set; }
    }
}
