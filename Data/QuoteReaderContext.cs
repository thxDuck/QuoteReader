using Microsoft.EntityFrameworkCore;

namespace QuoteReader.Data
{
    public class QuoteReaderContext : DbContext
    {
        public QuoteReaderContext(DbContextOptions<QuoteReaderContext> options)
            : base(options)
        {
        }

        public DbSet<Quote> Quote { get; set; } = default!;
    }
}
