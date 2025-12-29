using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            var userId = fetchedReview.UserId;
            var userName = _userManager.Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefault();
            return fetchedReview.ReviewToGetRequest(userName);
        }

        public async Task<ReviewGetRequest?> DeleteReviewAsync(Guid id)
        {
            var fetchedReview = await _reviewRepository.GetAsync(id);
            if(fetchedReview == null)
            {
                return null;
            }
            var userId = fetchedReview.UserId;
            var userName = _userManager.Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefault();
            await _reviewRepository.DeleteAsync(fetchedReview);
            return fetchedReview.ReviewToGetRequest(userName);
        }

        public async Task<IEnumerable<ReviewGetRequest>> GetAllReviewsAsync()
        {
            var fetchedReviews = await _reviewRepository.GetAllAsync();
            var users = fetchedReviews.Select(fr => fr.UserId).Distinct().ToList();
            var userNames = _userManager.Users.Where(u => users.Contains(u.Id)).Select(u => new { u.Id, u.UserName }).ToList();
            var usermap = userNames.ToDictionary(u => u.Id, u => u.UserName);
            var reviewsList = fetchedReviews.Select(r => r.ReviewToGetRequest(usermap.TryGetValue(r.UserId, out var name)
                ? name
                : "Deleted user")).ToList();
            return reviewsList;
        }

        public async Task<ReviewGetRequest?> GetReviewAsync(Guid id)
        {
            var fetchedReview = await _reviewRepository.GetAsync(id);
            if (fetchedReview==null)
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
            if (fetchedReviews.IsNullOrEmpty())
            {
                return null;
            }
            var users = fetchedReviews.Select(fr => fr.UserId).Distinct().ToList();
            var userNames = _userManager.Users.Where(u => users.Contains(u.Id)).Select(u => new { u.Id, u.UserName }).ToList();
            var usermap = userNames.ToDictionary(u => u.Id, u => u.UserName);
            var reviewsList = fetchedReviews.Select(r => r.ReviewToGetRequest(usermap.TryGetValue(r.UserId, out var name)
                ? name
                : "Deleted user")).ToList();
            return reviewsList;
        }

        public async Task<List<ReviewGetRequest>?> GetReviewsByUserAsync(Guid userId)
        {
            var fetchedReviews = await _reviewRepository.GetByUserAsync(userId);
            if (fetchedReviews.IsNullOrEmpty())
            {
                return null;
            }
            var users = fetchedReviews.Select(fr => fr.UserId).Distinct().ToList();
            var userNames = _userManager.Users.Where(u => users.Contains(u.Id)).Select(u => new { u.Id, u.UserName }).ToList();
            var usermap = userNames.ToDictionary(u => u.Id, u => u.UserName);
            var reviewsList = fetchedReviews.Select(r => r.ReviewToGetRequest(usermap.TryGetValue(r.UserId, out var name)
                ? name
                : "Deleted user")).ToList();
            return reviewsList;
        }

        public async Task<ReviewGetRequest?> UpdateReviewAsync(Guid id, ReviewUpdateRequest request)
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
            request.UpdateRequestToReview(fetchedReview);
            await _reviewRepository.UpdateAsync();
            return fetchedReview.ReviewToGetRequest(userName);
        }
    }
}
