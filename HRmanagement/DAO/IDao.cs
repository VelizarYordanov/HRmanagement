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
        TModel Get(int id);
        int Delete(TModel entity);
        int Delete(int id);
        int Insert(TModel entity);
        int Update(TModel entity);
    }
}
