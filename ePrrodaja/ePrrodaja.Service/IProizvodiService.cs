using ePrrodaja.Model;
using ePrrodaja.Model.Request;
using ePrrodaja.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service
{
    namespace ePrrodaja.Service
    {
        public interface IProizvodiService : ICRUDEService<Proizvodi,ProizvodiSearchObject,ProizvodiInsertRequest,ProizvodiUpdateRequest>
        {
            //List<Proizvodi> GetList(ProizvodiSearchObject searchObject);
            public Proizvodi Activate(int id);
            public Proizvodi Edit(int id);
            public Proizvodi Hide(int id);
            public List<string> AllowedActions(int id);
        }
    }

}
