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
    
    public class FakeSuperheroSkillsRepository : IRepository<SuperheroSkills>
    {
        List<SuperheroSkills> _list = new List<SuperheroSkills>();
        public FakeSuperheroSkillsRepository()
        {
            Random rand = new Random();
            int k = 1;
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < 10; j++)
                    _list.Add(new SuperheroSkills()
                    {
                        Id = k,
                        Name = $"SKill {k++}", 
                        SuperheroId = i, 
                        Damage = rand.Next(1000), 
                        Description = "",
                        UpgradeLevel = rand.Next(100),
                    });
        }
        public async Task<IReadOnlyList<SuperheroSkills>> ListAsync(
            Expression<Func<SuperheroSkills, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<SuperheroSkills, object>>[]? includesProperties
            )
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task AddAsync(SuperheroSkills entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(SuperheroSkills entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SuperheroSkills> FirstOrDefaultAsync(Expression<Func<SuperheroSkills, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SuperheroSkills> GetByIdAsync(int id, CancellationToken cancellationToken, params Expression<Func<SuperheroSkills, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<SuperheroSkills>> ListAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SuperheroSkills entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
