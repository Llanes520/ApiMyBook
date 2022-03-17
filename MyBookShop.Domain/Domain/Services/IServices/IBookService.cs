using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Books;
using MyBook.Domain.Domain.Dto.Editoriales;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services.IServices
{
    public interface IBookService
    {
        List<ConsultBookDto> GetAllBook();
        public List<TypeBookDto> GetAllTypeBook();
        List<EditorialDto> GetAllEditorial();
        Task<ResponseDto> DeleteBookAsync(int book);
        Task<bool> InsertBookAsync(BookDto book);
        Task<bool> UpdateBookAsync(BookDto book);
    }
}
