using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Dal
{
    public class ReaderContext : DbContext
    {
        public DbSet<RfidReaderWrapper> ReaderWrappers { get; set; }

        public DbSet<TagInfo> TagInfos { get; set; }

        public DbSet<ActivateEvent> ActivateEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\;Database=Readers;Integrated Security=True");
        }
    }
}
