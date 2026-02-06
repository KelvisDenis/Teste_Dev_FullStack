using Microsoft.EntityFrameworkCore;
using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Domain.Entities;
using Teste_Dev_FullStack.Domain.Enums;
using Teste_Dev_FullStack.Domain.Interfaces.Repositories;
using Teste_Dev_FullStack.Infraestructure.Data;

namespace Teste_Dev_FullStack.Infraestructure.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly MyContextDB _context;
        public PersonRepository(MyContextDB context) => _context = context;

        public async Task<Person> AddAsync(Person entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Person entity cannot be null.");
            await _context.PersonsSet.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.PersonsSet.ToListAsync();
        }

        public Task<Person?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid ID.", nameof(id));

            return _context.PersonsSet.FirstOrDefaultAsync(c => c.Id == id);
        }
        public Task<bool> HasTransacoesAsync(Guid personId)
        {
            if (personId == Guid.Empty) throw new ArgumentException("Invalid person ID.", nameof(personId));

            return _context.TransectionsSet.AnyAsync(t => t.PersonId == personId);
        }

        public Task<Person> UpdateAsync(Person entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Person entity cannot be null.");

            _context.PersonsSet.Update(entity);

            return Task.FromResult(entity);
        }
        public async Task<IEnumerable<Person>> GetTotalsGroupedByPersonAsync()
        {
            return await _context.PersonsSet.ToListAsync();
        }

        public Task DeleteAsync(Person entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Person entity cannot be null.");

            _context.PersonsSet.Remove(entity);

            return Task.FromResult(entity);
        }
    }
}
