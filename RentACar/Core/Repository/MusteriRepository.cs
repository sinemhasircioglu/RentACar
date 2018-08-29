using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class MusteriRepository : IMusteriRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Musteris.Count();
        }

        public void Delete(int id)
        {
            var silinecekMusteri = GetById(id);
            if(silinecekMusteri != null)
            {
                _context.Musteris.Remove(silinecekMusteri);
            }
        }

        public Musteri Get(Expression<Func<Musteri, bool>> expression)
        {
            return _context.Musteris.FirstOrDefault(expression);
        }

        public IEnumerable<Musteri> GetAll()
        {
            return _context.Musteris.Select(x => x);
        }

        public Musteri GetById(int id)
        {
            return _context.Musteris.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Musteri> GetMany(Expression<Func<Musteri, bool>> expression)
        {
            return _context.Musteris.Where(expression);
        }

        public void Insert(Musteri obj)
        {
            _context.Musteris.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Musteri obj)
        {
            _context.Musteris.AddOrUpdate();
        }
    }
}