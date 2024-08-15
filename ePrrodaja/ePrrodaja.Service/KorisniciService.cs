using ePrrodaja.Model.Request;
using ePrrodaja.Model.SearchObject;
using ePrrodaja.Service.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ePrrodaja.Service
{
    public class KorisniciService : BaseCRUDEService<Model.Korisnici,KorisniciSearchObject,Korisnici,KorisniciInsertRequest,KorisniciUpdateRequest>,IKorisniciService
    {
        ILogger<KorisniciService> _logger;
        public KorisniciService(EProdajaContext dbContext, IMapper mapper, ILogger<KorisniciService> logger) :base(dbContext,mapper)
        {
            _logger = logger;
        }

        ////Imamo u BaseService
      
        //public virtual List<Model.Korisnici> GetList(KorisniciSearchObject searchObject)
        //{
        //    List<Model.Korisnici> resulst = new List<Model.Korisnici>();

        //    var query = _dbContext.Korisnici.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
        //    {
        //        query = query.Where(x => x.KorisnickoIme.StartsWith(searchObject.ImeGTE));
        //    }

        //    if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
        //    {
        //        query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
        //    }

        //    if(!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
        //    {
        //        query = query.Where(x=>x.KorisnickoIme ==  searchObject.KorisnickoIme);
        //    }

        //    if (!string.IsNullOrEmpty(searchObject?.Email))
        //    {
        //        query = query.Where(x=>x.Email == searchObject.Email);  
        //    }

        //    if (searchObject.IsKOrisnicakUlogaIncludet == true)
        //    {
        //        query = query.Include(x => x.KorisniciUloges).ThenInclude(x => x.Uloga);
        //    }

        //    if(searchObject?.Page.HasValue==true && searchObject.PageSize.HasValue == true)
        //    {
        //        query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
        //    }

        //    var list = query.ToList();
        //    resulst = _mapper.Map(list, resulst);

        //    return resulst;
        //}

        public override IQueryable<Korisnici> AddFilter(KorisniciSearchObject searchObject, IQueryable<Korisnici> query)
        {

            query = base.AddFilter(searchObject,query);

            if (!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
            {
                query = query.Where(x => x.KorisnickoIme.StartsWith(searchObject.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == searchObject.KorisnickoIme);
            }

            if (!string.IsNullOrEmpty(searchObject?.Email))
            {
                query = query.Where(x => x.Email == searchObject.Email);
            }

            if (searchObject.IsKOrisnicakUlogaIncludet == true)
            {
                query = query.Include(x => x.KorisniciUloges).ThenInclude(x => x.Uloga);
            }

            return query;
        }

        public override void BeforeInsert(KorisniciInsertRequest request, Korisnici entity)
        {
            _logger.LogInformation($"Add User: { entity.KorisnickoIme}");  
            
            base.BeforeInsert(request, entity);

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka se ne podudara");
            }
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
        }

        //public Model.Korisnici Insert(KorisniciInsertRequest request)
        //{
        //    if (request.Lozinka != request.LozinkaPotvrda)
        //    {
        //        throw new Exception("Lozinke nisu iste");
        //    }
        //    //Korisnici entity1 = _mapper.Map<Korisnici>(request);

        //    Korisnici entity = new Korisnici();

        //    _mapper.Map(request, entity); // izvor i destinacija

        //    entity.LozinkaSalt = GenerateSalt();
        //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

        //    _dbContext.Add(entity);
        //    _dbContext.SaveChanges();

        //    return _mapper.Map<Model.Korisnici>(entity);
        //}


        public override void BeforeUpdate(KorisniciUpdateRequest request, Korisnici entity)
        {
            base.BeforeUpdate(request, entity);
            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Pass se ne podudara");
                }
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }

        }

        //public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        //{
        //    var entity = _dbContext.Korisnici.Find(id);
        //    _mapper.Map(request, entity);

        //    if(request.Lozinka != null)
        //    {
        //        if (request.Lozinka != request.LozinkaPotvrda)
        //        {
        //            throw new Exception("Pass se ne podudara");
        //        }
        //        entity.LozinkaSalt = GenerateSalt();
        //        entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
        //    }

        //    _dbContext.SaveChanges();

        //    return _mapper.Map<Model.Korisnici>(entity);
        //}

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Korisnici Login(string username, string password)
        {
           var entity = _dbContext.Korisnici.Include(x=>x.KorisniciUloges).ThenInclude(y=>y.Uloga).FirstOrDefault(e=> e.KorisnickoIme == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);
            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return _mapper.Map<Model.Korisnici>(entity);

        }

      
    }
}
