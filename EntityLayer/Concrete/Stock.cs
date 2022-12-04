using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int Flour { get; set; }
        public int Water { get; set; } 
        public int Salt{ get; set; }
        public int Yeast{ get; set; }
        
    }
}
