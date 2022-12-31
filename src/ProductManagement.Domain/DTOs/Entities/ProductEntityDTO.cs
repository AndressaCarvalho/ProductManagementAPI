using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.DTOs.Entities
{
    public class ProductEntityDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Unicode(false)]
        public string? Description { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ManufacturingDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        [Column("Provider_Id")]
        public int? ProviderId { get; set; }
    }
}
