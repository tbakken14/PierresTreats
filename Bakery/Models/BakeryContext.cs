using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions options) : base(options) { }
    }
}