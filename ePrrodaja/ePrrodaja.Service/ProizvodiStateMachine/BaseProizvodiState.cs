using ePrrodaja.Model.Request;
using ePrrodaja.Service.Database;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service.ProizvodiStateMachine
{
    public class BaseProizvodiState
    {
        public EProdajaContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }   

        public BaseProizvodiState(EProdajaContext context, IMapper mapper,IServiceProvider serviceProvider) {
            _context = context;
            _mapper = mapper;
            _serviceProvider= serviceProvider;
        }

        public virtual Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            throw new Exception("Method not Allowed");
        }

        public virtual Model.Proizvodi Update(int id,ProizvodiUpdateRequest request)
        {
            throw new Exception("Method not Allowed");
        }

        public virtual Model.Proizvodi Activate(int id)
        {
            throw new Exception("Method not Allowed");
        }

        public virtual Model.Proizvodi Edit(int id)
        {
            throw new Exception("Method not Allowed");
        }

        public virtual Model.Proizvodi Hide(int id)
        {
            throw new Exception("Method not Allowed");
        }


        //Na osnovu stanja vracamo klasu.
        public BaseProizvodiState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return _serviceProvider.GetService<InitialProizvodiState>();

                case "draft":
                    return _serviceProvider.GetService<DraftProizvodiState>();

                case "active":
                    return _serviceProvider.GetService<ActiveProizvodiState>();

                case "hiden":
                    return _serviceProvider.GetService<HideProizvodiState>();

                default:throw new Exception("State not recognized");
            }
        }



        //PSalje UI podatke koja dugmad da budu vidljiva ovisno od satnja u kojem se pbjekat nalazai i to overajdamo u svakoj izvedenoj klasi.
        public virtual List<string> AllowedActions(Proizvodi entity)
        {
            throw new Exception("Method not Allowed");
        }


    }
}
