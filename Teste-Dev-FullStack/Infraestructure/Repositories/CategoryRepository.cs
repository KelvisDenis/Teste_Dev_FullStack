using Microsoft.EntityFrameworkCore;
using Teste_Dev_FullStack.Domain.Entities;
using Teste_Dev_FullStack.Domain.Interfaces.Repositories;
using Teste_Dev_FullStack.Infraestructure.Data;

namespace Teste_Dev_FullStack.Infraestructure.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly MyContextDB _context;
        public CategoryRepository(MyContextDB context) => _context = context;
       
        public async Task<Category> AddAsync(Category entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Category entity cannot be null.");
            
            await _context.CategoriesSet.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.CategoriesSet.ToListAsync();
        }

        public Task<Category?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid category ID.", nameof(id));

            return _context.CategoriesSet.FirstOrDefaultAsync(c => c.Id ==id);
        }

        public Task<Category> UpdateAsync(Category entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Category entity cannot be null.");
            
            _context.CategoriesSet.Update(entity);

            return Task.FromResult(entity);
        }
        public Task DeleteAsync(Category entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Category entity cannot be null.");

            _context.CategoriesSet.Remove(entity);

            return Task.FromResult(entity);
        }

    }
}
