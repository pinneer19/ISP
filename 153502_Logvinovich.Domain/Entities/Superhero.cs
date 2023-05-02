using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Domain.Entities
{
    public class Superhero : Entity
    {
        public int Age { get; set; }
        public int Power { get; set; }
        public List<SuperheroSkills>? Skills { get; set; }

    }
    
}
