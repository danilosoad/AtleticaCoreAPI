using AtleticaCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Repository
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class ;
        void Update<T>(T entity) where T : class ;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Usuario[]> GetAllUsersAsync();
    }
}
