using ePrrodaja.Model;
using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ePrrodaja.Service
{
    public abstract class BaseService<TModel,TSearch,TDbEntity> : IService<TModel,TSearch> where TModel : class where TSearch : BaseSearchObject where TDbEntity : class
    {
        public IMapper _mapper { get; set; }
        
        public EProdajaContext _dbContext { get; set; }

        public BaseService(EProdajaContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual TModel GetById(int id)
        {
            var entity = _dbContext.Set<TDbEntity>().Find(id); 
            if(entity == null)
            {
                return null;
            }
            else
            {
            //    TModel test = null;
            //    test = _mapper.Map(entity, test);
            //    return test;
                return _mapper.Map<TModel>(entity);
            }
        }

        public virtual PagedResult<TModel> GetList(TSearch search)
        {
            List<TModel> result = new List<TModel>(); // postavi novu listu 

            var query = _dbContext.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);

            //Ovo je za Pagination  
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            int count = query.Count();
 
            var list = query.ToList();

            result = _mapper.Map(list, result);


            PagedResult<TModel> pagedResult = new PagedResult<TModel>();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
        {
            return query;
        }

    }
}
