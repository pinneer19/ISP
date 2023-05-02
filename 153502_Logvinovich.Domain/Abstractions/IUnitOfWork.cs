using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Superhero> SuperheroRepository { get; }
        IRepository<SuperheroSkills> SuperheroSkillsRepository { get; }
        public Task RemoveDatbaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
