using _153502_Logvinovich.Domain.Abstractions;
using _153502_Logvinovich.Domain.Entities;
using _153502_Logvinovich.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Persistence.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Superhero>> _superheroRepository;
        private readonly Lazy<IRepository<SuperheroSkills>> _skillsRepository;
        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _superheroRepository = new Lazy<IRepository<Superhero>>(() => new EfRepository<Superhero>(context));
            _skillsRepository = new Lazy<IRepository<SuperheroSkills>>(() => new EfRepository<SuperheroSkills>(context));
        }

        IRepository<Superhero> IUnitOfWork.SuperheroRepository => _superheroRepository.Value;
        
        IRepository<SuperheroSkills> IUnitOfWork.SuperheroSkillsRepository => _skillsRepository.Value;
        
        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }
        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
