using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public static class BorrowingMapper
    {
        public static BorrowingGetRequest BorrowingToGetDto(this Borrowing borrowing)
        {
            return new(
                borrowing.BookCopy.Title,
                borrowing.LibraryId,
                borrowing.BorrowedDate,
                borrowing.DueDate,
                borrowing.ReturnedAt,
                borrowing.IsOverdue);
        }

        public static void CreateDtoToBorrowing(this BorrowingCreateRequest request, Borrowing borrowing) 
        { 
            borrowing.BookCopyId = request.BookCopyId;
            borrowing.LibraryId = request.LibraryId;
            borrowing.DueDate = request.DueDate;
        }

        public static void UpdateDtoToBorrowing(this BorrowingUpdateRequest request, Borrowing borrowing)
        {
            borrowing.DueDate = request.DueDate;
            borrowing.ReturnedAt = request.ReturnedAt;
        }
    }
}
