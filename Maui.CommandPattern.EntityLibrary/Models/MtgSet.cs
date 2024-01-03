using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.CommandPattern.EntityLibrary.Models
{
    public class MtgSet : ModelBase
    {
        [Required]
        public int ReleaseYear { get; set; }
    }
}
