using Application.Common.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace Presentation.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork unit;

        public VillaController(IUnitOfWork unitOfWork)
        {
            this.unit = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Villa> villas = await unit.Villa.GetAllAsync();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Villa villa)
        {
            if (ModelState.IsValid)
            {
                await unit.Villa.SaveImage(villa);
                await unit.Villa.CreateAsync(villa);
                TempData["Success"] = "Villa has been created succesfully";
                return RedirectToAction("Index", "Villa");
            }
            TempData["Error"] = "Villa failed to be created";
            return RedirectToAction("Create","Villa");
        }

        public async Task<IActionResult> Update(int VillaId)
        {
            Villa? villa = await unit.Villa.GetAsync(v => v.Id == VillaId);
            if (villa == null || villa.Id == 0)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Villa villa)
        {
            if (ModelState.IsValid && villa.Id > 0)
            {
                if(villa.ImageFile != null)
                {
                    await unit.Villa.DeleteImage(villa);
                    await unit.Villa.SaveImage(villa);
                }
                await unit.Villa.UpdateAsync(villa);
                TempData["Success"] = "Villa has been updated succesfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Villa failed to be updated";
            return View();
        }

        public async Task<IActionResult> Delete(int VillaId)
        {
            Villa? villa = await unit.Villa.GetAsync(v => v.Id == VillaId);
            if (villa == null || villa.Id == 0)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Villa villa)
        {
            if (villa is not null && villa.Id > 0)
            {
                await unit.Villa.DeleteImage(villa);
                await unit.Villa.DeleteAsync(villa);
                TempData["Success"] = "Villa has been removed succesfully";
                return RedirectToAction("Index", "Villa");
            }
            TempData["Error"] = "Villa failed to be removed ";
            return View();
        }
    }
}
