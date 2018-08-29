using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Kullanicis.Count();
        }

        public void Delete(int id)
        {
            var silinecekKullanici = GetById(id);
            if(silinecekKullanici != null)
            {
                _context.Kullanicis.Remove(silinecekKullanici);
            }
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanicis.FirstOrDefault(expression);
        }

        public IEnumerable<Kullanici> GetAll()
        {
            return _context.Kullanicis.Select(x => x);
        }

        public Kullanici GetById(int id)
        {
            return _context.Kullanicis.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Kullanici> GetMany(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanicis.Where(expression);
        }

        public void Insert(Kullanici obj)
        {
            _context.Kullanicis.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kullanici obj)
        {
            _context.Kullanicis.AddOrUpdate(obj);
        }
    }
}