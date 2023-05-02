using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Persistence.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IRepository<Superhero> SuperheroRepository => new FakeSuperheroRepository();

        public IRepository<SuperheroSkills> SuperheroSkillsRepository => new FakeSuperheroSkillsRepository();

        public Task CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveDatbaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
