using ImagesStoreInDb.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImagesStoreInDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageEntity = new ImageEntity
                {
                    ImageData = memoryStream.ToArray(),
                    ContentType = file.ContentType
                };

                _context.Images.Add(imageEntity);
                await _context.SaveChangesAsync();

                return Ok(new { id = imageEntity.Id });
            }
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var imageEntity = await _context.Images.FindAsync(id);
            if (imageEntity == null)
                return NotFound();

            return File(imageEntity.ImageData, imageEntity.ContentType);
        }

    }
}
