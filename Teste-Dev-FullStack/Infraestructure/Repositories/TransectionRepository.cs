using Microsoft.EntityFrameworkCore;
using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Domain.Entities;
using Teste_Dev_FullStack.Domain.Enums;
using Teste_Dev_FullStack.Domain.Interfaces.Repositories;
using Teste_Dev_FullStack.Infraestructure.Data;

namespace Teste_Dev_FullStack.Infraestructure.Repositories
{
    public class TransectionRepository: ITransectionRepository
    {
        private readonly MyContextDB _context;
        public TransectionRepository(MyContextDB context) => _context = context;

        public async Task<Transection> AddAsync(Transection entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Transection entity cannot be null.");
            await _context.TransectionsSet.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<Transection>> GetAllAsync()
        {
            return await _context.TransectionsSet.ToListAsync();
        }

        public Task<Transection?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid ID.", nameof(id));

            return _context.TransectionsSet.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<IEnumerable<Transection>> GetByPersonIdAsync(Guid personId)
        {
            if (personId == Guid.Empty) throw new ArgumentException("Invalid person ID.", nameof(personId));    

            return await _context.TransectionsSet.Where(t => t.PersonId == personId).ToListAsync();
        }
        public async Task<bool> HasTransacoesAsync(Guid personId)
        {
            if (personId == Guid.Empty) throw new ArgumentException("Invalid person ID.", nameof(personId));
            return await _context.TransectionsSet.AnyAsync(t => t.PersonId == personId);
        }
        public async Task DeleteByPersonIdAsync(Guid personId)
        {
            if(personId == Guid.Empty) throw new ArgumentException("Invalid person ID.", nameof(personId));
               
            var transections = await _context.TransectionsSet.Where(t => t.PersonId == personId).ToListAsync();

            _context.TransectionsSet.RemoveRange(transections);

            await Task.CompletedTask;
        }

        public Task<Transection> UpdateAsync(Transection entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Transection entity cannot be null.");

            _context.TransectionsSet.Update(entity);

            return Task.FromResult(entity);
        }
        public Task DeleteAsync(Transection entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Transection entity cannot be null.");

            _context.TransectionsSet.Remove(entity);

            return Task.FromResult(entity);
        }
    }
}
