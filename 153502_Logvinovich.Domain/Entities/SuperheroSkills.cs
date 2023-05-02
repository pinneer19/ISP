using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Domain.Entities
{

    public class SuperheroSkills : Entity
    {
        public string Description { get; set; } = "";
        public int Damage { get; set; }
       
        public Superhero? Superhero { get; set; }
        public int SuperheroId { get; set; }
        public int UpgradeLevel { get; set; }
    }

}
