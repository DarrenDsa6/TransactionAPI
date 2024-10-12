
using TransactionAPI.Models.Domain;

namespace TransactionAPI.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task<IEnumerable<Transaction>> GetTransactionsByBrokerId(int brokerId);
        Task<IEnumerable<Transaction>> GetTransactionsByBuyerId(int buyerId);
        Task UpdateTransaction(Transaction transaction);
    }
}
