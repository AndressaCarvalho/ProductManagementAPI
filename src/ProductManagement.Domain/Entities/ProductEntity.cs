using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public bool? Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ManufacturingDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        [Column("Provider_Id")]
        public int? ProviderId { get; set; }
    }
}
