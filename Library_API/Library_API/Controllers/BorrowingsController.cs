using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    //[Authorize]
    public class BorrowingsController : Controller
    {
        private readonly IBorrowingService _borrowingService;
        public BorrowingsController(IBorrowingService borrowingService) 
        {
            _borrowingService = borrowingService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBorrowingById([FromRoute]Guid id)
        {
            var borrowing = await _borrowingService.GetBorrowingAsync(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, BorrowingGetRequest>()
            {
                ["borrowing"] = borrowing
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetBorrowingsByUser([FromQuery]Guid userId)
        {
            var borrowing = await _borrowingService.GetBorrowingsByUserAsync(userId);
            if(borrowing == null)
            {  
                return NotFound(); 
            }
            var output = new Dictionary<string, IEnumerable<BorrowingGetRequest>>()
            {
                ["borrowings"] = borrowing
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("book")]
        public async Task<IActionResult> GetBorrowingsByBook([FromQuery] Guid bookId)
        {
            var borrowing = await _borrowingService.GetBorrowingsByBookAsync(bookId);
            if (borrowing == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<BorrowingGetRequest>>()
            {
                ["borrowings"] = borrowing
            };
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> AddBorrowing([FromBody] BorrowingCreateRequest request)
        {
            bool ableToReserve = true;
            if (!ableToReserve)
                return Ok("Cannot make borrowing because either user is blocked or there are no available books");
            var borrowing = await _borrowingService.CreateBorrowingAsync(request);
            var output = new Dictionary<string, BorrowingGetRequest>()
            {
                ["borrowing"] = borrowing
            };
            return CreatedAtAction(nameof(AddBorrowing), output);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBorrowing([FromRoute] Guid id, [FromBody]BorrowingUpdateRequest request)
        {
            var borrowing = await _borrowingService.UpdateBorrowingAsync(id, request);
            if (borrowing == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBorrowing([FromRoute]Guid id)
        {
            var borrowing = await _borrowingService.DeleteBorrowingAsync(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
