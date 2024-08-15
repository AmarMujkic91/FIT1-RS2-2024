using ePrrodaja.Model;
using ePrrodaja.Model.Request;
using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ePrrodaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : BaseCRUDEController<Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {

        // protected IKorisniciService _services;

        public KorisniciController(IKorisniciService services) : base(services)
        {
            // _services = services;
        }

        //[HttpGet]
        //public List<Korisnici> GetList([FromQuery]KorisniciSearchObject searchObject)
        //{
        //    return _services.GetList(searchObject);
        //}

        //[HttpPost]
        //public Korisnici Insert(KorisniciInsertRequest request)
        //{
        //    return _services.Insert(request);
        //}

        //[HttpPut("{id}")]
        //public Korisnici Update(int id, KorisniciUpdateRequest request)
        //{
        //    return _services.Update(id, request);
        //}
        [AllowAnonymous]
        public override PagedResult<Korisnici> GetList([FromQuery] KorisniciSearchObject search)
        {
            return base.GetList(search);
        }

        [HttpPost("login")]
        public Korisnici Login(string username, string password)
        {
            return (_service as IKorisniciService).Login(username, password);
        }
    }
}
