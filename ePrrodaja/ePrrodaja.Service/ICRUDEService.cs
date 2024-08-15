using ePrrodaja.Model.SearchObject;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service
{
    public interface ICRUDEService<TModel,TSearch,TInsert,TUpdate> : IService<TModel,TSearch> where TModel : class where TSearch : BaseSearchObject
    {
        public TModel Insert(TInsert request);
        public TModel Update(int i, TUpdate request);
    }
}
