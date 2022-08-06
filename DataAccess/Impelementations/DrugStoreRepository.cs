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
    public class DrugStoreRepository : IRepository<DrugStore>
    {
        private static int id;
        public DrugStore Create(DrugStore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.DrugStores.Add(entity);
                return entity;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Delete(DrugStore entity)
        {
            try
            {
                DbContext.DrugStores.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public DrugStore Get(Predicate<DrugStore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugStores[0];
                }
                else
                {
                    return DbContext.DrugStores.Find(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<DrugStore> GetAll(Predicate<DrugStore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugStores;
                }
                else
                {
                    return DbContext.DrugStores.FindAll(filter);

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }

        }

        public void Update(DrugStore entity)
        {
            try
            {
                var drugStore = DbContext.DrugStores.Find(d => d.Id == entity.Id);
                if (drugStore != null)
                {
                    drugStore.Name = entity.Name;
                    drugStore.Adresss = entity.Adresss;
                    drugStore.ContactNumber = entity.ContactNumber;
                    drugStore.Owner = entity.Owner;

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
