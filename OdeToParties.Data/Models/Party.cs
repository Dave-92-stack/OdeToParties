using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToParties.Data.Models
{
    public class Party
    {
        public int Id { get; set; }

        [Required]
        public string Host { get; set; }

        [Display(Name ="Type of venue")]
        public VenueType Venue { get; set; }
    }
}
