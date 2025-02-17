using Microsoft.EntityFrameworkCore;

namespace Crowd_Funding.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CrowdFundingContext context;
        protected readonly DbSet<T> table;

        public GenericRepository(CrowdFundingContext _context)
        {
            context = _context;
            table = _context.Set<T>();
        }
        public void Delete(T Entity)
        {
            table.Remove(Entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task InsertAsync(T Entity)
        {
            await table.AddAsync(Entity);
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(T Entity)
        {
            table.Update(Entity);
        }


    }
}
