
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
    public interface IKorisniciService : ICRUDEService<Korisnici,KorisniciSearchObject,KorisniciInsertRequest,KorisniciUpdateRequest>
    {
        //List<Korisnici> GetList(KorisniciSearchObject searchObject);
        //Korisnici Insert(KorisniciInsertRequest request);
        //Korisnici Update(int id, KorisniciUpdateRequest request);

        Korisnici Login(string username, string password);
    }
}
