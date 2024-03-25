using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BazToGo.Models
{
    public class Locations
    {
        [Key]
        public int IDLocation { get; set; }
        public string LocationName { get; set; }
        public string DropPoint { get; set; }
        public string CardinalDirection { get; set; }
    }
}
