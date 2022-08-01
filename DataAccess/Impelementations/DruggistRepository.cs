using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Impelementations
{
    public class DruggistRepository : IRepository<Druggist>
    {
        private static int id;
        public Druggist Create(Druggist entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Druggists.Add(entity);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Druggist entity)
        {
            try
            {
                DbContext.Druggists.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Druggist Get(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Druggists[0];
                }
                else
                {
                    return DbContext.Druggists.Find(filter);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Druggist> GetAll(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {

                    return DbContext.Druggists;
                }
                else
                {
                    return DbContext.Druggists.FindAll(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }

        }

        public void Update(Druggist entity)
        {
            try
            {
                if (entity != null)
                {
                    var druggist = DbContext.Druggists.Find(D => D.Id == entity.Id);
                    druggist.Name = entity.Name;
                    druggist.Surname = entity.Surname;
                    druggist.Age = entity.Age;
                    druggist.DrugStore = entity.DrugStore;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
