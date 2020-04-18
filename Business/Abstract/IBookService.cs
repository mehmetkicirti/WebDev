using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //İş Kodu works Here
    //Örneğin bir adam kredi alıcak uygunmu
    //Dataaccess ile iletiişim kurar.
    //İş kuralları değişken olduğu için sadece dataAccess de kullanılır ortak bir Erişim katmanı generic yapı olusturmak core dataaccess deki
    public interface IBookService
    {
        //Ortak bir interface Business Katmanında olmaz değişkenlik gösterebilir her bir servise göre
        //burada artık yapacagımız işleri tanımlıyoruz
        List<Book> GetAll();
        Book GetById(int id);
        List<Book> GetByAuthorId(int authorId);
        
        //List<Book> GetByIsbn(string Isbn);
        void Add(Book entity);
        void Delete(Book entity);
        void Update(Book entity);
    }
}
