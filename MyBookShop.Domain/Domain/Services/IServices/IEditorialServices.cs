using MyBook.Domain.Domain.Dto.Editoriales;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services.IServices
{
    public interface IEditorialServices
    {
        List<EditorialDto> GetAllEditorial(); 
        Task<ResponseDto> DeleteEditorialAsync(int idEditorial);
        Task<bool> InsertEditorialAsync(EditorialDto editorial);
        Task<bool> UpdateEditorialAsync(EditorialDto Edit);
    }
}
