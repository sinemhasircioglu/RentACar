using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class ResimRepository : IResimRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Resims.Count();
        }

        public void Delete(int id)
        {
            var silinecekResim = GetById(id);
            if(silinecekResim != null)
            {
                _context.Resims.Remove(silinecekResim);
            }
        }

        public Resim Get(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resims.FirstOrDefault(expression);
        }

        public IEnumerable<Resim> GetAll()
        {
            return _context.Resims.Select(x => x);
        }

        public Resim GetById(int id)
        {
            return _context.Resims.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Resim> GetMany(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resims.Where(expression);
        }

        public void Insert(Resim obj)
        {
            _context.Resims.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Resim obj)
        {
            _context.Resims.AddOrUpdate();
        }
    }
}