using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.DTOs.Entities
{
    public class ProductEntityDTO : BaseEntityDTO
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
