using MedicalAppointment.Domain.Commons;

namespace MedicalAppointment.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(long id);
    Task<bool> RemoveAsync(long id);
}