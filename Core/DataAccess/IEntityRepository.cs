using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //constraint ekliyoruz  class olmalı ve newlenebilir olmalı.
    //IEntity nesneyi imzaladıgımız bir interfacedir
    //Bu imzayı kim kullanıyorsa o bir veritabanı nesnesidir.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // new() => interface vermesini engellemek icin 
        //T yi IEntity Nesnesinden türemis oldugu bir zorunluluk Oldugu için Book,Author yazıcaz..
        //How is it work ? Ne işe yarar  => Genel operasyonalrımızı burada tanımlayıp bunu kullanıcak olan sınıflara Soyut bir imza görevi görücek.
        T Get(Expression<Func<T, bool>> filter); // r.Get(b => b.Id == 2);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
