
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Common.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>,IVillaNumberRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VillaNumberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return dbContext.Villas.Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            }).ToList();
        }

        public bool HasVillaNumber(VillaNumber villaNumber)
        {
            return dbContext.VillaNumbers.Contains(villaNumber);
        }
    }
}
