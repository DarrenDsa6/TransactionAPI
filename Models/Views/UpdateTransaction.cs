using TransactionAPI.Models.Domain;

namespace TransactionAPI.Models.Views
{
    public class UpdateTransactionDto
    {
        public decimal? Amount { get; set; }
        public TransactionStatus? Status { get; set; }
    }
}
