using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalTallyCounter.Models
{
    public class TallyCounter
    {
        [Required]
        [StringLength(512, ErrorMessage = "Tally Counter List Name cannot more than 512 length!")]
        public string Name { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
