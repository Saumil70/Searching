using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searching.Models
{
    public class ProductVariantMappings
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }  
        public int VariantId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }
        [ForeignKey("VariantId")]
        public virtual Variants Variants { get; set; }
    }
}
