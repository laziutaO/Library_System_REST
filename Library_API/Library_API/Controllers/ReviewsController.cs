using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            if (reviews == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<ReviewGetRequest>>()
            {
                ["reviews"] = reviews
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetReview([FromRoute] Guid id)
        {
            var review = await _reviewService.GetReviewAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, ReviewGetRequest>()
            {
                ["review"] = review
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetReviewsByUser([FromQuery] Guid userId)
        {
            var reviews = await _reviewService.GetReviewsByUserAsync(userId);
            if (reviews == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<ReviewGetRequest>>()
            {
                ["reviews"] = reviews
            };
            return Ok(output);
        }

        [HttpGet]
        [Route("book")]
        public async Task<IActionResult> GetReviewsByBook([FromQuery] Guid bookId)
        {
            var reviews = await _reviewService.GetReviewsByBookAsync(bookId);
            if (reviews == null)
            {
                return NotFound();
            }
            var output = new Dictionary<string, IEnumerable<ReviewGetRequest>>()
            {
                ["reviews"] = reviews
            };
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewCreateRequest reservRequest)
        {
            var review = await _reviewService.CreateReviewAsync(reservRequest);
            var output = new Dictionary<string, ReviewGetRequest>()
            {
                ["reviews"] = review
            };
            return CreatedAtAction(nameof(AddReview), output);  
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReview([FromRoute] Guid id, [FromBody] ReviewUpdateRequest updateRequest)
        {
            var review = await _reviewService.UpdateReviewAsync(id, updateRequest);

            if (review == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid id)
        {
            var review = await _reviewService.DeleteReviewAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
