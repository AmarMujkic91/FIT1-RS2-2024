using ePrrodaja.Service.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service.ProizvodiStateMachine
{
    public class HideProizvodiState : BaseProizvodiState
    {
        public HideProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Model.Proizvodi Edit(int id)
        {
            var set = _context.Set<Proizvodi>();

            var entity = set.Find(id);

            entity.StateMachine = "draft";

            _context.SaveChanges();

            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override List<string> AllowedActions(Proizvodi entity)
        {
            return new List<string>() { nameof(Edit) };
        }
    }
}
