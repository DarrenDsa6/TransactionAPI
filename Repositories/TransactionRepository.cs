
using Microsoft.EntityFrameworkCore;
using TransactionAPI.Data;
using TransactionAPI.Models.Domain;

namespace TransactionAPI.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByBrokerId(int brokerId)
        {
            return await _context.Transactions.Where(t => t.BrokerId == brokerId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByBuyerId(int buyerId)
        {
            return await _context.Transactions.Where(t => t.BuyerId == buyerId).ToListAsync();
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
