using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext applicationDb)
        {
            Villa = new VillaRepository(applicationDb);
            VillaNumber = new VillaNumberRepository(applicationDb);
        }
        public IVillaRepository Villa { get; private set; }

        public IVillaNumberRepository VillaNumber { get; private set; }
    }
}
