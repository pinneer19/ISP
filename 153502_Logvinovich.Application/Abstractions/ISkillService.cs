using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Application.Abstractions
{
    public interface ISkillService
    {
        Task<IEnumerable<SuperheroSkills>> GetAllSkillsAsync(Expression<Func<SuperheroSkills, bool>> filter);
        Task<SuperheroSkills> GetByIdAsync(int id);
        Task AddAsync(SuperheroSkills skill);
        Task UpdateAsync(SuperheroSkills skill);
        Task DeleteAsync(SuperheroSkills skill);
        
    }
}
