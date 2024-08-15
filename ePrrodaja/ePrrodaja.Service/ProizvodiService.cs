using ePrrodaja.Model;
using ePrrodaja.Model.Request;
using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service.Database;
using ePrrodaja.Service.ePrrodaja.Service;
using ePrrodaja.Service.ProizvodiStateMachine;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ePrrodaja.Service
{
    public class ProizvodiService : BaseCRUDEService<Model.Proizvodi, ProizvodiSearchObject, Database.Proizvodi,ProizvodiInsertRequest,ProizvodiUpdateRequest>, IProizvodiService
    {
        //    public EProdajaContext _dbContext { get; set; }
        //    public IMapper _mapper { get; set; }
        ILogger<ProizvodiService> _logger;
        public BaseProizvodiState _baseProizvodiState { get; set; }

        public ProizvodiService(EProdajaContext dbContext, IMapper mapper, BaseProizvodiState baseProizvodiState, ILogger<ProizvodiService> logger) : base(dbContext, mapper)
        {
            _baseProizvodiState = baseProizvodiState;
            _logger = logger;
        }

        public override IQueryable<Database.Proizvodi> AddFilter(ProizvodiSearchObject search, IQueryable<Database.Proizvodi> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x=>x.Naziv.Contains(search.FTS));
            }

            return filteredQuery;
        }

        //ovdje umjeto baznog inserta koristimo virtual InitialProizvodi state insert i za to na treba gore u konstruktoru BaseProizvodState
        public override Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            var state = _baseProizvodiState.CreateState("initial"); // instanciramo pravu  klasu za to stanje  //ovo smo hard kodali 
            return state.Insert(request);
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest request)
        {
            var entity = GetById(id);
            var state = _baseProizvodiState.CreateState(entity.StateMachine); // instanciramo pravu  klasu za to stanje
            return state.Update(id, request);
        }


        //-------------------------------------------OVE DOLE NE POSTOJE U ICRUDEService PA SE MORAJU IMPLEMENTIRAT U IProizvodiService----------------------------------------------

        public Model.Proizvodi Activate(int id)
        {
            var entity = GetById(id);
            var state = _baseProizvodiState.CreateState(entity.StateMachine); // instanciramo pravu  klasu za to stanje
            return state.Activate(id); // u vracenoj klasi pozivamo metodu ako je nema onda idemo na base proizovid State i bacamo eception 
        }

        public Model.Proizvodi Edit(int id)
        {
            var entity = GetById(id);
            var state = _baseProizvodiState.CreateState(entity.StateMachine); // instanciramo pravu  klasu za to stanje
            return state.Edit(id); // u vracenoj klasi pozivamo metodu ako je nema onda idemo na base proizovid State i bacamo eception 
        }

        public Model.Proizvodi Hide(int id)
        {
            var entity = GetById(id);
            var state = _baseProizvodiState.CreateState(entity.StateMachine); // instanciramo pravu  klasu za to stanje
            return state.Hide(id); // u vracenoj klasi pozivamo metodu ako je nema onda idemo na base proizovid State i bacamo eception 
        }

        public List<string> AllowedActions(int id)
        {
            _logger.LogInformation($" Allow action called for: {id}");
            if (id <= 0)
            {
                var state = _baseProizvodiState.CreateState("initial"); //ovo smo hard kodali 
                return state.AllowedActions(null);
            }
            else
            {
                //citamo direktno entitet  jer imamo vise informacija a getByID nam vraca model ne entity
                var entity = _dbContext.Proizvodi.Find(id);
                var state = _baseProizvodiState.CreateState(entity.StateMachine); // instanciramo pravu  klasu za to stanje
                return state.AllowedActions(entity); // u vracenoj klasi pozivamo metodu ako je nema onda idemo na base proizovid State i bacamo eception 
            }
            
            throw new NotImplementedException();
        }

    

        //public virtual List<Model.Proizvodi> GetList(ProizvodiSearchObject searchObject)
        //{
        //    // Ovo je kod bez searchObject 
        //    //var list = _dbContext.Proizvodi.ToList();

        //    //var result = new List<Model.Proizvodi>();

        //    //foreach (var item in list)
        //    //{
        //    //    result.Add(new Model.Proizvodi()
        //    //    {
        //    //        ProizovdiID = item.ProizvodId,
        //    //        Naziv = item.Naziv,
        //    //        Cijena = item.Cijena
        //    //    });
        //    //}
        //    //return result;

        //    var query = _dbContext.Proizvodi.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(searchObject?.FTS))
        //    {
        //        query = query.Where(x => x.Naziv.Contains(searchObject.FTS) || x.Sifra.Contains(searchObject.FTS));
        //    }

        //    if (searchObject?.Page.HasValue == true && searchObject?.PageSize.HasValue == true)
        //    {
        //        query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
        //    }

        //    var list = query.ToList();

        //    List<Model.Proizvodi> result = new List<Model.Proizvodi>();

        //    _mapper.Map(list, result);

        //    return result;
        //}
    }
}
