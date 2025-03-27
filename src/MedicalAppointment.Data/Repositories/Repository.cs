using MedicalAppointment.Data.DbContexts;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>(); 
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updateEntry =  _context.Update(entity);
        await _context.SaveChangesAsync();
        return updateEntry.Entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsQueryable(); 
    }

    public async Task<TEntity> GetByIdAsync(long id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<bool> RemoveAsync(long id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        if (entity is null)
        {
            return false;
        }
        
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
           
    }
}