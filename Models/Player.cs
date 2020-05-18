using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransferMarket.Models
{
    public class Player
    {

        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
       
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Position { get; set; }
        public string League { get; set; }
        public int Market_Value { get; set; }
    }
}
