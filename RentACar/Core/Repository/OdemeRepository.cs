using RentACar.Core.Infrastructure;
using RentACar.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RentACar.Core.Repository
{
    public class OdemeRepository : IOdemeRepository
    {
        private readonly RentACarEntities _context = new RentACarEntities();

        public int Count()
        {
            return _context.Odemes.Count();
        }

        public void Delete(int id)
        {
            var silinecekOdeme = GetById(id);
            if (silinecekOdeme != null)
            {
                _context.Odemes.Remove(silinecekOdeme);
            }
        }

        public Odeme Get(Expression<Func<Odeme, bool>> expression)
        {
            return _context.Odemes.FirstOrDefault(expression);
        }

        public IEnumerable<Odeme> GetAll()
        {
            return _context.Odemes.Select(x => x);
        }

        public Odeme GetById(int id)
        {
            return _context.Odemes.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Odeme> GetMany(Expression<Func<Odeme, bool>> expression)
        {
            return _context.Odemes.Where(expression);
        }

        public void Insert(Odeme obj)
        {
            _context.Odemes.Add(obj);
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

        public void Update(Odeme obj)
        {
            _context.Odemes.AddOrUpdate();
        }
    }
}