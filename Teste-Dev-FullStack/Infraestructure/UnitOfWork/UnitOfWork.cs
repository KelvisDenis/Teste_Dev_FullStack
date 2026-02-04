
using Teste_Dev_FullStack.Infraestructure.Data;

namespace Teste_Dev_FullStack.Infraestructure.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContextDB _context;
        public UnitOfWork(MyContextDB context) => _context = context;

        public async Task RoolbackAsync()
        {
           
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
