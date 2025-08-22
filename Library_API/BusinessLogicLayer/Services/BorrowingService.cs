using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _repository;
        public BorrowingService(IBorrowingRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<bool> CheckIfCanBorrow(Guid userId, Guid bookId)
        {
            return await _repository.CheckIfCanBorrowAsync(userId, bookId);
        }

        public async Task<BorrowingGetRequest> CreateBorrowingAsync(BorrowingCreateRequest request)
        {
            Borrowing borrowing = new Borrowing();
            request.CreateDtoToBorrowing(borrowing);
            await _repository.CreateAsync(borrowing);
            var fetchedReservation = await _repository.GetAsync(borrowing.Id);
            if (fetchedReservation == null)
            {
                throw new InvalidOperationException("Reservation could not be retrieved after creation.");
            }
            return fetchedReservation.BorrowingToGetDto();
        }

        public async Task<BorrowingGetRequest> DeleteBorrowingAsync(Guid id)
        {
            var borrowing = await _repository.GetAsync(id);

            if (borrowing == null)
            {
                return null;
            }

            await _repository.DeleteAsync(borrowing);
            return borrowing.BorrowingToGetDto();
        }

        public async Task<BorrowingGetRequest?> GetBorrowingAsync(Guid id)
        {
            var borrowing = await _repository.GetAsync(id);
            return borrowing == null ? null : borrowing.BorrowingToGetDto();
        }

        public async Task<List<BorrowingGetRequest>?> GetBorrowingsByBookAsync(Guid bookId)
        {
            var borrowings = await _repository.GetByBookAsync(bookId);
            if (borrowings == null)
            {
                return null;
            }
            var borrowingsList = borrowings.Select(b => b.BorrowingToGetDto()).ToList();
            return borrowingsList;
        }

        public async Task<List<BorrowingGetRequest>?> GetBorrowingsByUserAsync(Guid userId)
        {
            var borrowings = await _repository.GetByUserAsync(userId);
            if (borrowings == null)
            {
                return null;
            }
            var borrowingsList = borrowings.Select(b => b.BorrowingToGetDto()).ToList();
            return borrowingsList;
        }

        public async Task<BorrowingGetRequest?> UpdateBorrowingAsync(Guid id, BorrowingUpdateRequest request)
        {
            var borrowing = await _repository.GetAsync(id);

            if (borrowing == null)
            {
                return null;
            }
            request.UpdateDtoToBorrowing(borrowing);
            await _repository.UpdateAsync();

            return borrowing.BorrowingToGetDto();
        }
    }
}
