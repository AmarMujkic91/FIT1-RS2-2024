using ePrrodaja.Model;
using ePrrodaja.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service
{
    public interface IService<TModel,TSearch> where TSearch : BaseSearchObject
    {
        public PagedResult<TModel> GetList(TSearch search);
        public TModel GetById(int id);
    }
}
