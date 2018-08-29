using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace RentACar.Core.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Rols.Count();
        }

        public void Delete(int id)
        {
            var silinecekRol = GetById(id);
            if(silinecekRol != null)
            {
                _context.Rols.Remove(silinecekRol);
            }
        }

        public Rol Get(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rols.FirstOrDefault(expression);
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Rols.Select(x => x);
        }

        public Rol GetById(int id)
        {
            return _context.Rols.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rols.Where(expression);
        }

        public void Insert(Rol obj)
        {
            _context.Rols.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Rol obj)
        {
            _context.Rols.AddOrUpdate();
        }
    }
}