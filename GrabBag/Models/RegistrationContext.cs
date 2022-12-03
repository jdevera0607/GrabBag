using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GrabBag.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
        : base(options)
        { }

        public DbSet<Register> Registers { get; set; }
    }
}
