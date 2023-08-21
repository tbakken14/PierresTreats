using System.Collections.Generic;

namespace Bakery.Models
{
    public class Treat
    {
        public int TreatId { get; set; }
        public string Name { get; set; }
        public List<TreatFlavor> TreatFlavors { get; set; }
    }
}