﻿using AtleticaCore.Data;
using AtleticaCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Repository
{
    public class UserRepository : IUserRepository
    {
        public DataContext _context { get; }

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }

        public async Task<Usuario[]> GetAllUsersAsync()
        {
            var result = _context.Usuarios.OrderBy(x => x.ID);

            return await result.ToArrayAsync();
        }

        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            var result = _context.Usuarios.AsNoTracking().Where(x =>x.ID == id);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUserByLogin(string login)
        {
            var result = _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.LOGIN.Equals(login));

            return await result;
        }
    }
}
