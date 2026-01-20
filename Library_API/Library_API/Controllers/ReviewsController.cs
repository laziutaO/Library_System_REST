using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewCreateRequest reservRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                return Unauthorized();

            var userGuid = Guid.Parse(userId);

            var review = await _reviewService.CreateReviewAsync(reservRequest, userGuid);
            var output = new Dictionary<string, ReviewGetRequest>()
            {
                ["reviews"] = review
            };
            return CreatedAtAction(nameof(AddReview), output);  
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
