using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
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
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
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
            return fetchedReview?.ReviewToGetRequest();
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
