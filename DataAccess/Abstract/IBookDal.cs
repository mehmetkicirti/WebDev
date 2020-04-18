using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Operasyonlar burada tanımlandı Book nesnesi için
    //Özel Operasyonalrımızı burada tanımlıcaz book a özel 
    public interface IBookDal:IEntityRepository<Book>
    {
    }
}
