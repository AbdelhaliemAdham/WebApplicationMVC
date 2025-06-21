using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Models;

namespace Application.Common.Interfaces
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        public IEnumerable<SelectListItem> GetSelectListItems();
        public bool HasVillaNumber(VillaNumber villaNumber);

    }
}
