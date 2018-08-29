using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class AracRepository : IAracRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Aracs.Count();
        }

        public void Delete(int id)
        {
            var silinecekArac = GetById(id);
            if (silinecekArac != null)
            {
                _context.Aracs.Remove(silinecekArac);
            }
        }

        public Arac Get(Expression<Func<Arac, bool>> expression)
        {
            return _context.Aracs.FirstOrDefault(expression);
        }

        public IEnumerable<Arac> GetAll()
        {
            return _context.Aracs.Select(x => x);
        }

        public Arac GetById(int id)
        {
            return _context.Aracs.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Arac> GetMany(Expression<Func<Arac, bool>> expression)
        {
            return _context.Aracs.Where(expression);
        }

        public void Insert(Arac obj)
        {
            _context.Aracs.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Arac obj)
        {
            _context.Aracs.AddOrUpdate();
        }
    }
}