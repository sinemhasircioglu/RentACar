using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class HizmetRepository : IHizmetRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Hizmets.Count();
        }

        public void Delete(int id)
        {
            var silinecekHizmet = GetById(id);
            if(silinecekHizmet != null)
            {
                _context.Hizmets.Remove(silinecekHizmet);
            }
        }

        public Hizmet Get(Expression<Func<Hizmet, bool>> expression)
        {
            return _context.Hizmets.FirstOrDefault(expression);
        }

        public IEnumerable<Hizmet> GetAll()
        {
            return _context.Hizmets.Select(x => x);
        }

        public Hizmet GetById(int id)
        {
            return _context.Hizmets.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Hizmet> GetMany(Expression<Func<Hizmet, bool>> expression)
        {
            return _context.Hizmets.Where(expression);
        }

        public void Insert(Hizmet obj)
        {
            _context.Hizmets.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Hizmet obj)
        {
            _context.Hizmets.AddOrUpdate();
        }
    }
}