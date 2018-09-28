using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;

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
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine(string.Format("Entity türü \"{0}\" şu hatalara sahip \"{1}\" Geçerlilik hataları:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine(string.Format("- Özellik: \"{0}\", Hata: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
            }
        }

        public void Update(Resim obj)
        {
            _context.Resims.AddOrUpdate();
        }
    }
}