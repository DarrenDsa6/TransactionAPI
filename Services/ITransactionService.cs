
using TransactionAPI.Models.Domain;

namespace TransactionAPI.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task<IEnumerable<Transaction>> GetTransactionsByBrokerId(int brokerId);
        Task<IEnumerable<Transaction>> GetTransactionsByBuyerId(int buyerId);
        Task UpdateTransaction(Transaction transaction);
    }
}
