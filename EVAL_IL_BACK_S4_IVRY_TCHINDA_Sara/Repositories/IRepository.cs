using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Repositories

{
    public interface IRepository <TEntity>
    {
        Task<TEntity> GetById (int id);
        Task<IEnumerable<TEntity>> GetAll ();
        Task Create (TEntity entity);
        Task Update (TEntity entity);
        Task Delete (TEntity entity);
    }
}
