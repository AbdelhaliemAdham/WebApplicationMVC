
using Application.Common.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository;


namespace Infrastructure.Services
{
    public class VillaRepository : Repository<Villa>,IVillaRepository

        {

        public VillaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task DeleteImage(Villa villa)
        {
            if (villa == null) throw new ArgumentNullException(nameof(villa));
            if(villa.Image != null)
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", villa?.Image?.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            return Task.CompletedTask;
        }

        public async Task SaveImage(Villa villa)
        {
            if(villa == null) throw new ArgumentNullException(nameof(villa));
            var fileName = villa?.ImageFile?.FileName ?? villa?.ImageFile?.Name;
            if (fileName == null) throw new ArgumentNullException(nameof(villa));
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Villa",fileName);
            using FileStream filestreem = new FileStream(path, FileMode.Create);
            await villa?.ImageFile?.CopyToAsync(filestreem);
            villa.Image = "/Villa/" + fileName;
        }
    }
}
