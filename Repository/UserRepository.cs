using Common.EntityClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ElectronicsStoreContext _context;

        public UserRepository(ElectronicsStoreContext context)
        {
            _context = context;
        }

        public async Task<Common.EntityClass.UserDetails> GetUser(string username, string password)
        {
            return await _context.UserDetails
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

    }
}

