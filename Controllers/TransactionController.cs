using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Models.Domain;
using TransactionAPI.Models.Views;
using TransactionAPI.Services;

namespace TransactionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _services;

        public TransactionsController(ITransactionService services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                PropertyId = dto.PropertyId,
                BuyerId = dto.BuyerId,
                BrokerId = dto.BrokerId,
                TransactionDate = dto.TransactionDate,
                Amount = dto.Amount,
                Status = dto.Status
            };

            var result = await _services.CreateTransaction(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = result.TransactionId }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransactions()
        {
            return Ok(await _services.GetAllTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _services.GetTransactionById(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpGet("broker/{brokerId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByBrokerId(int brokerId)
        {
            return Ok(await _services.GetTransactionsByBrokerId(brokerId));
        }

        [HttpGet("buyer/{buyerId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByBuyerId(int buyerId)
        {
            return Ok(await _services.GetTransactionsByBuyerId(buyerId));
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            var transaction = await _services.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            // Update properties if they are provided
            if (dto.Amount.HasValue)
            {
                transaction.Amount = dto.Amount.Value;
            }

            if (dto.Status.HasValue)
            {
                transaction.Status = dto.Status.Value;
            }

            // Save the updated transaction
            await _services.UpdateTransaction(transaction);

            return NoContent(); // Indicate that the update was successful
        }

    }
}
