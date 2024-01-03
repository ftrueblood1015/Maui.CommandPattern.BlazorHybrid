using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.CommandPattern.EntityLibrary.Models
{
    public class MtgCard : ModelBase
    {
        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public int? MtgSetId { get; set; }

        public MtgSet? MtgSet { get; set; }
    }
}
