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

        public void Update(Arac obj)
        {
            _context.Aracs.AddOrUpdate();
        }
    }
}