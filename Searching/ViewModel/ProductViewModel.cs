using Searching.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Searching.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; } 
        public int VariantId { get; set; }  
        public  int ProductId { get; set; }   
        public int Ram {  get; set; }
        public int Storage {  get; set; }
        public string Processor { get; set; }

        [ForeignKey("ProductId")]

        public virtual Products Products { get; set; }

    }
}
