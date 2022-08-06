using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DrugStore : IEntity
    {
        public DrugStore()
        {
            Druggists = new List<Druggist>();
            Drugs = new List<Drug>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adresss { get; set; }
        public string ContactNumber { get; set; }
        public List<Druggist> Druggists { get; set; }
        public List<Drug> Drugs { get; set; }
        public  Owner Owner { get; set; }

    }
}
