using HumbleBob.Bll.Dto.Enums;
using System;

namespace HumbleBob.Web.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Desciption { get; set; }

        public decimal Price { get; set; }

        public StorageUnit StorageUnit { get; set; }

        public bool IsDeleted { get; set; }
    }
}
