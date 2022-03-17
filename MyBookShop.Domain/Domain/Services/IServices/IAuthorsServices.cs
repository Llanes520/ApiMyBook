using MyBook.Domain.Domain.Dto;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services.IServices
{
    public interface IAuthorsServices
    {
        List<AuthorsDto> GetAllAthors();
        Task<ResponseDto> DeleteAuthorsAsync(int idAuthors);
        Task<bool> InsertAuthorsAsync(AuthorsDto book);
        Task<bool> UpdateAuthorsAsync(AuthorsDto authors);
    }
}
