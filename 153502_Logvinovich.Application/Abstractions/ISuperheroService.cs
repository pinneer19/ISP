using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Application.Abstractions
{
    public interface ISuperheroService
    {
 
        Task<IEnumerable<Superhero>> GetAllSuperheroesAsync();
        Task<Superhero> GetByIdAsync(int id);
        Task AddAsync(Superhero superhero);
        Task UpdateAsync(Superhero superhero);
        Task DeleteAsync(Superhero superhero);
    }
}
