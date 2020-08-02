using System.Threading.Tasks;

namespace Hospital.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
