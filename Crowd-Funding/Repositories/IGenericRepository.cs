namespace Crowd_Funding.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        Task<int> SaveAsync();
    }
}
