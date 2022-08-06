using Core.Abstractions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Druggist : Person, IEntity
    {
        public int Id { get; set; }
        public byte Age { get; set; }
        public double Experience { get; set; }
        public DrugStore DrugStore { get; set; }


    }
}
