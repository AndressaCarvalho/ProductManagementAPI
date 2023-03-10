using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Domain.DTOs.Entities
{
    [Index("Cnpj", Name = "UQ__Provider__A299CC922F4210A1", IsUnique = true)]

    public class ProviderEntityDTO : BaseEntityDTO
    {
        [Required]
        [StringLength(18)]
        [Unicode(false)]
        public string? Cnpj { get; set; }
    }
}
