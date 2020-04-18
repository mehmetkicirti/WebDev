using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //Kitapla ilgili servisleri burada yönetiyoruz artık
    public class BookManager : IBookService
    {
        //IbookdAL field vermemizin yalnızca sebebi erişebililelim diye
        //interfaceler referans tiptir bu yüzden hangi referansı verirsem onu kullanarak
        private IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public void Add(Book entity)
        {
            //iş kodu
            //Örnegin bu iş kuralını biz birden fazla yerde kullanabiliriz bu yüzden bu kod kötü bunu ayrı bir yerde ele almamız lazım.
            if(_bookDal.Get(b=>b.Name == entity.Name && b.AuthorId == entity.AuthorId) == null)
            {
                _bookDal.Add(entity);
            }else throw new Exception("Bu kitap daha önce eklenmiş");
        }

        public void Delete(Book entity)
        {
            _bookDal.Delete(entity);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetList().ToList();   
        }

        public List<Book> GetByAuthorId(int authorId)
        {
            return _bookDal.GetList(b=> b.AuthorId == authorId).ToList();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(b=>b.Id == id);
        }

        public void Update(Book entity)
        {
            _bookDal.Update(entity);
        }
    }
}
