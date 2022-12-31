using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Domain.Entities
{
    [Index("Cnpj", Name = "UQ__Provider__A299CC922F4210A1", IsUnique = true)]

    public class ProviderEntity : BaseEntity
    {
        [StringLength(18)]
        [Unicode(false)]
        public string? Cnpj { get; set; }
    }
}
