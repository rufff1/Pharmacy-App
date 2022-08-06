using Core.Abstractions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Owner :Person, IEntity
    {

        public Owner()
        {
            Drugstores = new List<DrugStore>();
        }
        public int Id { get; set; }
        public List<DrugStore> Drugstores { get; set; }
    }
}
