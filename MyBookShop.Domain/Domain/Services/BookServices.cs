using Common.Utils.Enums;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Books;
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

        public List<ConsultBookDto> GetAllBook(int idbook)
        {
            var pets = _unitOfWork.BooksRepository.FindAll(x => x.IdBook == idbook,
                                                        p => p.TypeBookEntity,
                                                        p => p.StateEntity).ToList();

            List<ConsultBookDto> list = pets.Select(x => new ConsultBookDto
            {
                IdBook = x.IdBook,
                Name = x.Name,
                Descriptin = x.Descriptin,
                Author = x.Author,
                DatePreRealease = x.DatePreRealease,
                DateRealease = x.DateRealease,
                IdTypeBook = x.IdTypeBook,
                IdState = x.IdState,
                TypeBook = x.TypeBookEntity.TypeBook,
                State = x.StateEntity.State,

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

        public async Task<ResponseDto> DeleteBookAsync(int idBook)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.BooksRepository.Delete(idBook);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente la Mascota";
            else
                response.Message = "Hubo un error al eliminar la Mascota, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> InsertBookAsync(InsertBookDto book, int idUser)
        {
             UserBookEntity userBookEntity = new UserBookEntity()
            {
                IdUser = idUser,
                bookEntity = new BookEntity()
                {
                    Name = book.Name,
                    Descriptin = book.Descriptin,
                    Author = book.Author,
                    DatePreRealease = book.DatePreRealease,
                    IdTypeBook = book.IdTypeBook,
                    IdState = (int)Enums.State.Preaprobado,
                }
            };

            _unitOfWork.UserBookRepository.Insert(userBookEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBookAsync(BookDto book)
        {
            bool result = false;

            BookEntity bookEntity = _unitOfWork.BooksRepository.FirstOrDefault(x => x.IdBook == book.IdBook);
            if (bookEntity != null)
            {
                bookEntity.Name = book.Name;
                bookEntity.Descriptin = book.Descriptin;
                bookEntity.Author = book.Author;
                bookEntity.DatePreRealease = book.DatePreRealease;
                bookEntity.IdTypeBook = book.IdTypeBook;

                _unitOfWork.BooksRepository.Update(bookEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        #endregion
    }
}
