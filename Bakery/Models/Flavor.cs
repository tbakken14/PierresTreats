using System.Collections.Generic;
using Bakery.Migrations;

namespace Bakery.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        public string Name { get; set; }
        public List<TreatFlavor> TreatFlavors { get; set; }
    }
}