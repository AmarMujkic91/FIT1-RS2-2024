using ePrrodaja.Model;
using ePrrodaja.Model.Request;
using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service;
using ePrrodaja.Service.ePrrodaja.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ePrrodaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : BaseCRUDEController<Proizvodi,ProizvodiSearchObject,ProizvodiInsertRequest,ProizvodiUpdateRequest>
    {
        //protected IProizvodiService _service;

        public ProizvodiController(IProizvodiService service):base(service)
        {
            //_service = service;
        }

        [HttpPut("{id}/activate")]
        public Proizvodi Activate(int id)
        {
            return (_service as IProizvodiService).Activate(id);
        }

        [HttpPut("{id}/edit")]
        public Proizvodi Edit(int id)
        {
            return (_service as IProizvodiService).Edit(id);
        }

        [HttpPut("{id}/hide")]
        public Proizvodi Hide(int id)
        {
            return (_service as IProizvodiService).Hide(id);
        }

        [HttpGet("{id}/allowedActions")]
        public List<string> AllowedActions(int id)
        {
            return (_service as IProizvodiService).AllowedActions(id);
        }

        //[HttpGet]
        //public PagedResult<Proizvodi> GetList([FromQuery]ProizvodiSearchObject searchObject)
        //{
        //    return _service.GetList(searchObject);
        //}

        //[HttpGet("{id}")]
        //public Proizvodi GetById(int id)
        //{
        //    return _service.GetById(id);
        //}
    }
}
