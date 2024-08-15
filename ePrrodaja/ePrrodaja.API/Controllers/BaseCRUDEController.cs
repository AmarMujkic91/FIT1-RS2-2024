using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ePrrodaja.API.Controllers
{
    public class BaseCRUDEController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch> where TModel : class where TSearch : BaseSearchObject
    {  //odrdaimo casting 
        protected new ICRUDEService<TModel, TSearch, TInsert, TUpdate> _service;

        public BaseCRUDEController(ICRUDEService<TModel, TSearch, TInsert, TUpdate> service) : base(service)
        {  //odrdaimo casting 
            _service = service;
        }

        [HttpPost]
        public TModel Insert(TInsert request)
        {
            //odrdaimo casting 
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, TUpdate request)
        {
            return _service.Update(id, request);
        }
    }
}
