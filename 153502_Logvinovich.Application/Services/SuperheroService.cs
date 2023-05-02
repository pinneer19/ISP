using _153502_Logvinovich.Application.Abstractions;
using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Application.Services
{
    public class SuperheroService : ISuperheroService
    {
        private readonly IUnitOfWork _unit;

        public SuperheroService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public Task AddAsync(Superhero item)
        {
            return _unit.SuperheroRepository.AddAsync(item);
        }

        public Task DeleteAsync(Superhero superhero)
        {
            return _unit.SuperheroRepository.DeleteAsync(superhero);
        }

        public async Task<IEnumerable<Superhero>> GetAllSuperheroesAsync()
        {
            return await _unit.SuperheroRepository.ListAllAsync();
        }

        public Task<Superhero> GetByIdAsync(int id)
        {
            return _unit.SuperheroRepository.GetByIdAsync(id);
        }   

        public Task UpdateAsync(Superhero item)
        {
            return _unit.SuperheroRepository.UpdateAsync(item);
        }
    }
}
