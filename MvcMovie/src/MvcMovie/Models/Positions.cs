using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Positions
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
