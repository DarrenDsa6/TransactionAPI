using TransactionAPI.Models.Domain;

namespace TransactionAPI.Models.Views
{
    public class CreateTransactionDto
    {
        public int PropertyId { get; set; }
        public int BuyerId { get; set; }
        public int BrokerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
