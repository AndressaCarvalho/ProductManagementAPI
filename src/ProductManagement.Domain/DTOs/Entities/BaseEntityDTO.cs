using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.DTOs.Entities
{
    public class BaseEntityDTO
    {
        [StringLength(255)]
        [Unicode(false)]
        public string? Description { get; set; }
    }
}
