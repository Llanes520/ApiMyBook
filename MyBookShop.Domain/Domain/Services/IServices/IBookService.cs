using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Books;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services.IServices
{
    public interface IBookService
    {
        List<ConsultBookDto> GetAllBook(int idbook);
        public List<TypeBookDto> GetAllTypeBook();
        Task<ResponseDto> DeleteBookAsync(int idBook);
        Task<bool> InsertBookAsync(InsertBookDto book, int idUser);
        Task<bool> UpdateBookAsync(BookDto book);
    }
}
