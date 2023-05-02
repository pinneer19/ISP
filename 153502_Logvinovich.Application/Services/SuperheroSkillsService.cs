using _153502_Logvinovich.Application.Abstractions;
using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Application.Services
{
    public class SuperheroSkillsService : ISkillService
    {

        private readonly IUnitOfWork _unit;

        public SuperheroSkillsService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public Task AddAsync(SuperheroSkills item)
        {
            return _unit.SuperheroSkillsRepository.AddAsync(item);
        }

        public Task DeleteAsync(SuperheroSkills skills)
        {
            return _unit.SuperheroSkillsRepository.DeleteAsync(skills);
        }

        public async Task<IEnumerable<SuperheroSkills>> GetAllSkillsAsync(Expression<Func<SuperheroSkills,bool>> filter)
        {
            return await _unit.SuperheroSkillsRepository.ListAsync(filter);
        }

        public Task<SuperheroSkills> GetByIdAsync(int id)
        {
            return _unit.SuperheroSkillsRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(SuperheroSkills item)
        {
            return _unit.SuperheroSkillsRepository.UpdateAsync(item);
        }
    }
}
