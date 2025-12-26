using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReviewService(IReviewRepository reviewRepository,
                            UserManager<ApplicationUser> userManager)
        {
            _reviewRepository = reviewRepository;
            _userManager = userManager;
        }
        public async Task<ReviewGetRequest> CreateReviewAsync(ReviewCreateRequest request)
        {
            Review review = new Review();
            request.CreateRequestToReview(review);
            await _reviewRepository.CreateAsync(review);
            var fetchedReview = await _reviewRepository.GetAsync(review.Id);
            if (fetchedReview == null)
            {
                throw new InvalidOperationException("Reservation could not be retrieved after creation.");
            }
            return fetchedReview.ReviewToGetRequest();
        }

        public async Task<ReviewGetRequest?> DeleteReviewAsync(Guid id)
        {
            var fetchedReview = await _reviewRepository.GetAsync(id);
            if(fetchedReview == null)
            {
                return null;
            }
            await _reviewRepository.DeleteAsync(fetchedReview);
            return fetchedReview.ReviewToGetRequest();
        }

        public async Task<IEnumerable<ReviewGetRequest>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            List<ReviewGetRequest> reviewsList = reviews.Select(r => r.ReviewToGetRequest()).ToList();
            return reviewsList;
        }

        public async Task<ReviewGetRequest?> GetReviewAsync(Guid id)
        {
            var fetchedReview = await _reviewRepository.GetAsync(id);
            if (fetchedReview == null)
            {
                return null;
            }
            var userId = fetchedReview.UserId;
            var userName = _userManager.Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefault();

            return fetchedReview?.ReviewToGetRequest(userName);
        }

        public async Task<List<ReviewGetRequest>?> GetReviewsByBookAsync(Guid bookId)
        {
            var fetchedReviews = await _reviewRepository.GetByBookAsync(bookId);
            if (fetchedReviews == null)
            {
                return null;
            }

            List<ReviewGetRequest> reviewsList = fetchedReviews.Select(r => r.ReviewToGetRequest()).ToList();
            return reviewsList;
        }

        public async Task<List<ReviewGetRequest>?> GetReviewsByUserAsync(Guid userId)
        {
            var fetchedReviews = await _reviewRepository.GetByUserAsync(userId);
            if (fetchedReviews == null)
            {
                return null;
            }
            List<ReviewGetRequest> reviewsList = fetchedReviews.Select(r => r.ReviewToGetRequest()).ToList();
            return reviewsList;
        }

        public async Task<ReviewGetRequest?> UpdateReviewAsync(Guid id, ReviewUpdateRequest request)
        {
            var fetchedReview = await _reviewRepository.GetAsync(id);
            if (fetchedReview == null)
            {
                return null;
            }
            request.UpdateRequestToReview(fetchedReview);
            await _reviewRepository.UpdateAsync();
            return fetchedReview.ReviewToGetRequest();
        }
    }
}
