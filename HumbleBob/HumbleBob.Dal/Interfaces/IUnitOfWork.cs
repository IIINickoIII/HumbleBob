using HumbleBob.Dal.Entities;
using System.Threading.Tasks;

namespace HumbleBob.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Item> ItemRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
