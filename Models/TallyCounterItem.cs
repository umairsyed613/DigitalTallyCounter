using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalTallyCounter.Models
{
    public class TallyCounterItem
    {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [Required]
        [StringLength(512, ErrorMessage = "Tally Counter List Name cannot more than 512 length!")]
        public string Name { get; set; }

        public int CountValue { get; set; } = 0;

        public DateTime CreatedAt { get; set; }
    }
}
