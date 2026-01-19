using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Mapping
{
    public static class ReviewMapping
    {
        public static ReviewGetRequest ReviewToGetRequest(this Review review, string username)
        {
            return new(
                username,
                review.Book.Title,
                review.Rating,
                review.Comment,
                review.PostedDate);
        }

        public static void UpdateRequestToReview(this ReviewUpdateRequest request, Review review) 
        {
            review.Rating = request.Rating;
            review.Comment = request.Comment;
        }

        public static void CreateRequestToReview(this ReviewCreateRequest request, Review review, Guid userId)
        {
            review.UserId = userId;
            review.BookId = request.BookId;
            review.Rating = request.Rating;
            review.Comment = request.Comment;
        }
    }
}
