using CorporateMessenger.Data.Interfaces;
using CorporateMessenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMassenger.Data;
using Microsoft.EntityFrameworkCore;

namespace CorporateMessenger.Data.Repository
{
    internal sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Role> GetUserRoleByRoleNameAsync(string roleName)
        {
            return await Source
                      .FirstOrDefaultAsync(u => u.Name == roleName);
        }
    }
}
