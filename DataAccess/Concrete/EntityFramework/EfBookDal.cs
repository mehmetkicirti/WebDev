using Core.DataAccess.EF;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Sen IBookDal implementasyonusun
    //implemente etmemiz gerekir normalde fakat Biz zaten bunu core da Tanımladık
    //Bu yüzden EFresositoryBase den implemente edicez <Book nesnelerinden olusucak, Context olucak>
    //Artık Bu kitap nesnesine özel o implementasyonu core da tanımladıgımız operasyonlar buradada tanımlanmış oldu ayrıca
    //Context => Nesnelerin ile db ni birleştiren bir sınıftır. Ef de
    public class EfBookDal:EfRepositoryBase<Book,BookStoreContext>,IBookDal
    {
    }
}
