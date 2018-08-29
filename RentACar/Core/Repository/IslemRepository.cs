using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class IslemRepository : IIslemRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Islems.Count();
        }

        public void Delete(int id)
        {
            var silinecekIslem = GetById(id);
            if(silinecekIslem != null)
            {
                _context.Islems.Remove(silinecekIslem);
            }
        }

        public Islem Get(Expression<Func<Islem, bool>> expression)
        {
            return _context.Islems.FirstOrDefault(expression);
        }

        public IEnumerable<Islem> GetAll()
        {
            return _context.Islems.Select(x => x);
        }

        public Islem GetById(int id)
        {
            return _context.Islems.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Islem> GetMany(Expression<Func<Islem, bool>> expression)
        {
            return _context.Islems.Where(expression);
        }

        public void Insert(Islem obj)
        {
            _context.Islems.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Islem obj)
        {
            _context.Islems.AddOrUpdate();
        }
    }
}