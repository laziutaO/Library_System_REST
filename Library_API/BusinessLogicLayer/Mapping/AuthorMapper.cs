using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class AuthorMapper
    {
        public static AuthorGetRequest AuthorToGetDto(this Author author)
        {
            return new AuthorGetRequest
            {
                name = author.Name,
                books = author.BookAuthors.Select(ba => ba.Book.Title).ToList()
            };
        }
    }
}
