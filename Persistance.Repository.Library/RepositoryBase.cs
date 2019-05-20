using Core.Library;
using Core.Library.Entities;
using Core.Library.Persistance;
using Microsoft.EntityFrameworkCore;
using Persistance.Library;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repository.Library
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        public BoardGamesDbContext _dbContext { get; set; }
        public RepositoryBase(IBoardGamesDbContext dbContext)
        {
            _dbContext = dbContext as BoardGamesDbContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }


        public async Task<T> GetDetailsAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return await this._dbContext.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public void Create(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<T>> FindSpecifiedAmount(int? count)
        {
            if (count == null)
            {
                return await this._dbContext.Set<T>().ToListAsync();
            }
            else
            {
                int amount = count.GetValueOrDefault();
                return await this._dbContext.Set<T>().Take(amount).ToListAsync();

            }

        }
    }
}
