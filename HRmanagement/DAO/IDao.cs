using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.DAO
{
    interface IDao<TModel>
        where TModel : Models.Universal
    {
        List<TModel> GetAll();
        TModel GetByID(int id);
        TModel Get(string FilterName, string FilterValue);
        int Delete(TModel entity);
        int Delete(int id);
        ulong Insert(TModel entity);
        int Update(TModel entity);
    }
}
