
using TransactionAPI.Models.Domain;
using TransactionAPI.Repositories;

namespace TransactionAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<Transaction> CreateTransaction(Transaction transaction)
        {
            return _repository.AddTransaction(transaction);
        }

        public Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return _repository.GetAllTransactions();
        }

        public Task<Transaction> GetTransactionById(int id)
        {
            return _repository.GetTransactionById(id);
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByBrokerId(int brokerId)
        {
            return _repository.GetTransactionsByBrokerId(brokerId);
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByBuyerId(int buyerId)
        {
            return _repository.GetTransactionsByBuyerId(buyerId);
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            _repository.UpdateTransaction(transaction); // You will need to implement this in your repository
        }

    }
}
