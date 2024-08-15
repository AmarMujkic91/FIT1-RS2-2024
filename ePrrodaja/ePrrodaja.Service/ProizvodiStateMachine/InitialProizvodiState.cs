using ePrrodaja.Model.Request;
using ePrrodaja.Service.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service.ProizvodiStateMachine
{
    public class InitialProizvodiState : BaseProizvodiState
    {
        public InitialProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            //Pozivamo entity framework 
            var set = _context.Set<Proizvodi>();

            var enetity = _mapper.Map<Proizvodi>(request);

            enetity.StateMachine = "draft";

            set.Add(enetity);  // Zasto ovo ???
            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodi>(enetity);
        }

        public override List<string> AllowedActions(Proizvodi entity)
        {
            return new List<string>() { nameof(Insert) };  // znaci da ce imat isti naziv ko metoda insert mogli smo mi stavit i {"insert"} al je sigurnije zbog gresaka u tipkanju
        }
    }
}
