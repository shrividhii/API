using Common.DBEntityClass;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly ElectronicsStoreContextNew _context;

        public UserRepository(ElectronicsStoreContextNew context)
        {
            _context = context;
        }

        public async Task<UserDetail> GetUser(string username, string password)
        {
            return await _context.UserDetails
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

    }
}

