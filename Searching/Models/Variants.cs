using System.ComponentModel.DataAnnotations;

namespace Searching.Models
{
    public class Variants
    {
        [Key]
        public int VariantId {  get; set; } 
        public int  Ram {  get; set; }
        public string Storage {  get; set; }
        public string Processor { get; set; }   
    }
}
