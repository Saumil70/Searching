using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searching.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName {  get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Categories Categories { get; set; }

        public List<ProductVariantMappings> ProductVariantMappings { get; set; }

       
    }
}
