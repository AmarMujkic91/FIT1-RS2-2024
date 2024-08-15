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
    public class DraftProizvodiState : BaseProizvodiState
    {
        public DraftProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }


        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest request)
        {
            var set = _context.Set<Proizvodi>();

            var enetity = set.Find(id);

            _mapper.Map(request, enetity);

            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodi> (enetity);
        }

        public override Model.Proizvodi Activate(int id)
        {
            var set = _context.Set<Proizvodi>();

            var entity = set.Find(id);

            entity.StateMachine = "active";

            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override Model.Proizvodi Hide(int id)
        {
            var set = _context.Set<Proizvodi>();
            var entity = set.Find(id);

            entity.StateMachine = "hiden";

            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override List<string> AllowedActions(Proizvodi entity)
        {
            return new List<string>() { nameof(Update), nameof(Activate), nameof(Hide) };
        }
    }
}
