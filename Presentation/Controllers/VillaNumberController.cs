using Application.Common.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; 

namespace Presentation.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork unit;

        public VillaNumberController(IUnitOfWork unit)
        {
            this.unit = unit;
        }
       
        public async Task<IActionResult> Index()
        {
            var VillaNumbers = await unit.VillaNumber.GetAllAsync(includeParameters:"Villa");
            return View(VillaNumbers);
        }

        public IActionResult Create()
        {
            var list  = unit.VillaNumber.GetSelectListItems();
            ViewData["VillaList"] = list;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VillaNumber VillaNumber)
        {
            bool isAlreadyExist = unit.VillaNumber.HasVillaNumber(VillaNumber);
            if (isAlreadyExist)
            {
                TempData["Error"] = "VillaNumber is Already Exist";
                return RedirectToAction("Create", "VillaNumber");
            }
            
            ModelState.Remove("Villa");
            if (ModelState.IsValid)
            {
                await unit.VillaNumber.CreateAsync(VillaNumber);
                TempData["Success"] = "VillaNumber has been created succesfully";
                return RedirectToAction("Index", "VillaNumber");
            }
            TempData["Error"] = "VillaNumber failed to be created";
            return RedirectToAction("Create","VillaNumber");
        }
        
        public async Task<IActionResult> Update(int VillaNumberId)
        {
            ViewData["VillaList"] = unit.VillaNumber.GetSelectListItems();
            VillaNumber? VillaNumber = await unit.VillaNumber.GetAsync(v => v.Villa_Number == VillaNumberId,"Villa");
            if (VillaNumber == null || VillaNumber.Villa_Number == 0)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(VillaNumber);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VillaNumber VillaNumber)
        {
            ModelState.Remove("Villa");
            if (ModelState.IsValid && VillaNumber.Villa_Number > 0)
            {
                await unit.VillaNumber.UpdateAsync(VillaNumber);
                TempData["Success"] = "VillaNumber has been updated succesfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "VillaNumber failed to be updated";
            return View();
        }

        public async Task<IActionResult> Delete(int VillaNumberId)
        {
            ViewData["VillaList"] = unit.VillaNumber.GetSelectListItems();
            VillaNumber? VillaNumber = await unit.VillaNumber.GetAsync(v => v.Villa_Number == VillaNumberId);
            if (VillaNumber == null || VillaNumber.Villa_Number == 0)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(VillaNumber);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VillaNumber VillaNumber)
        {
            if (VillaNumber is not null && VillaNumber.Villa_Number > 0)
            {
               await unit.VillaNumber.DeleteAsync(VillaNumber);
                TempData["Success"] = "VillaNumber has been removed succesfully";
                return RedirectToAction("Index", "VillaNumber");
            }
            TempData["Error"] = "VillaNumber failed to be removed ";
            return View();
        }
    }
}
