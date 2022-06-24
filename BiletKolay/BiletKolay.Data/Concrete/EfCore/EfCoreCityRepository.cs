using BiletKolay.Data.Abstract;
using BiletKolay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Data.Concrete.EfCore
{
    public class EfCoreCityRepository : EfCoreGenericRepository<City, BiletKolayContext>, ICityRepository
    {
    }
}
