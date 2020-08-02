using Hospital.Core;
using System.Threading.Tasks;

namespace Hospital.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalsDbContext context;

        public UnitOfWork(HospitalsDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
