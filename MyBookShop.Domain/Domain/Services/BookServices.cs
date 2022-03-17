using Common.Utils.Enums;
using Common.Utils.Exeption;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Books;
using MyBook.Domain.Domain.Dto.Editoriales;
using MyBook.Domain.Domain.Services.IServices;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services
{
    public class BookServices : IBookService
    {
        #region Attributes

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Builder
        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public List<ConsultBookDto> GetAllBook()
        {

            var books = _unitOfWork.BooksRepository.GetAll(p => p.TypeBookEntity,
                                                            p => p.EditorialEntity,
                                                            p => p.Authors_Has_BooksEntities).ToList();

            List<ConsultBookDto> list = books.Select(x => new ConsultBookDto
            {
                IdBook = x.IdBook,
                Titulo = x.Titulo,
                Sipnosis = x.Sipnosis,
                Paginas = x.Num_Paginas,
                TypeBook = x.TypeBookEntity.TypeBook,
                IdTypeBook = x.IdTypeBook,
                IdEditorial = x.IdEditorial,
                Nombre = x.EditorialEntity.Nombre,

            }).ToList();


            return list;
        }

        public List<TypeBookDto> GetAllTypeBook()
        {
            List<TypeBookEntity> typePets = _unitOfWork.TypeBookRepository.GetAll().ToList();

            List<TypeBookDto> list = typePets.Select(x => new TypeBookDto
            {
                IdTypeBook = x.IdTypeBook,
                TypeBook = x.TypeBook
            }).ToList();

            return list;
        }

        public List<EditorialDto> GetAllEditorial()
        {
            List<EditorialEntity> typeEditorial = _unitOfWork.EditorialRepository.GetAll().ToList();

            List<EditorialDto> list = typeEditorial.Select(x => new EditorialDto
            {
                IdEditorial = x.IdEditorial,
                Nombre = x.Nombre
            }).ToList();

            return list;
        }

        public async Task<ResponseDto> DeleteBookAsync(int book)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.BooksRepository.Delete(book);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente el libro";
            else
                response.Message = "Hubo un error al eliminar el libro, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> InsertBookAsync(BookDto book)
        {
            Authors_has_BooksEntity authors_Has_BooksEntity = new Authors_has_BooksEntity()
            {
                Id_Authors = book.IdAuthors,
                BookEntity = new BookEntity()
                {
                    Titulo = book.Titulo,
                    Sipnosis = book.Sipnosis,
                    Num_Paginas = book.Paginas,
                    IdTypeBook = book.IdTypeBook,
                    IdEditorial = book.IdEditorial,
                }
            };

            _unitOfWork.Authors_has_BooksRepository.Insert(authors_Has_BooksEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBookAsync(BookDto book)
        {
            bool result = false;

            BookEntity bookEntity = _unitOfWork.BooksRepository.FirstOrDefault(x => x.IdBook == book.IdBook);
            if (bookEntity != null)
            {
                bookEntity.Titulo = book.Titulo;
                bookEntity.Sipnosis = book.Sipnosis;
                bookEntity.Num_Paginas = book.Paginas;
                bookEntity.IdTypeBook = book.IdTypeBook;
                bookEntity.IdEditorial = book.IdEditorial;

                _unitOfWork.BooksRepository.Update(bookEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        #endregion
    }
}
