using Microsoft.EntityFrameworkCore;
using TransactionAPI.Models.Domain;
using TransactionAPI;

namespace TransactionAPI.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
