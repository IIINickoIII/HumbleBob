using HumbleBob.Dal.Contexts;
using HumbleBob.Dal.Entities;
using HumbleBob.Dal.Interfaces;
using System.Threading.Tasks;

namespace HumbleBob.Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HumbleBobContext _context;

        private IBaseRepository<Item> _itemRepository;

        public UnitOfWork(HumbleBobContext context)
        {
            _context = context;
        }

        public IBaseRepository<Item> ItemRepository =>
            _itemRepository ??= new BaseRepository<Item>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
