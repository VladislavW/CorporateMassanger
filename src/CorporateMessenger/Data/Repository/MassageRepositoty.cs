using CorporateMessenger.Data.Interfaces;
using CorporateMessenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMassenger.Data;

namespace CorporateMessenger.Data.Repository
{
    internal sealed class MassageRepositoty : Repository<Massage>, IMassageRepositoty
    {
        protected readonly ApplicationContext _context;
        public MassageRepositoty(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
