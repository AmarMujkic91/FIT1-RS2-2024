using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service
{
    public abstract class BaseCRUDEService<TModel, TSearch, TDbEntity, TInsert, TUpdate> : BaseService<TModel, TSearch, TDbEntity> where TModel : class where TSearch : BaseSearchObject where TDbEntity : class 
                         
    {
        public BaseCRUDEService(EProdajaContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public virtual TModel Insert(TInsert request)
        {
            TDbEntity entity = _mapper.Map<TDbEntity>(request);
            BeforeInsert(request, entity); // ova linija koristimo ako imamo specijalne slucajve kao kod korisnika sto moramo has i to 
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert request, TDbEntity entity) { }




        public virtual TModel Update(int id, TUpdate request)
        {
            var set = _dbContext.Set<TDbEntity>();
            var entity = set.Find(id);

            //entity = _mapper.Map<TDbEntity>(request);
            _mapper.Map(request, entity);

            BeforeUpdate(request, entity);
            _dbContext.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual void BeforeUpdate(TUpdate request, TDbEntity entity) { }
    }
}
