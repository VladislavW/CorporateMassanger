using CorporateMassenger.Data.Mapping;
using CorporateMessenger.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMassenger.Data;
using Microsoft.EntityFrameworkCore;

namespace CorporateMessenger.Data.Repository
{
    internal sealed class UserRepository : Repository<User>, IUserRepositoty
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Source
                     .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
