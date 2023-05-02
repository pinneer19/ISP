using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Persistence.Repository
{
    
    public class FakeSuperheroRepository : IRepository<Superhero>
    {
        public List<Superhero> _superheroes;
        public FakeSuperheroRepository()
        {
            _superheroes= new List<Superhero>()
            {
                new Superhero() { Id=1, Name="Hulk", Skills = new(), Age = 100, Power = 1000},
                new Superhero(){ Id=2, Name="Superman", Skills = new(), Age = 100, Power = 1000 }
            };
        }

        public async Task<IReadOnlyList<Superhero>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _superheroes);
        }

        Task IRepository<Superhero>.AddAsync(Superhero entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Superhero>.DeleteAsync(Superhero entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Superhero> IRepository<Superhero>.FirstOrDefaultAsync(Expression<Func<Superhero, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Superhero> IRepository<Superhero>.GetByIdAsync(int id, CancellationToken cancellationToken, params Expression<Func<Superhero, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Superhero>> IRepository<Superhero>.ListAsync(Expression<Func<Superhero, bool>>? filter, CancellationToken cancellationToken, params Expression<Func<Superhero, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Superhero>.UpdateAsync(Superhero entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
