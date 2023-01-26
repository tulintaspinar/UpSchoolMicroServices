using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.PhotoStock.DTOs;
using UpSchoolECommerce.Shared.ControllerBases;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile formFile)
        {
            if(formFile!=null && formFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/photos",formFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream);
                var returnPath = "photos/"+formFile.FileName;
                PhotoDTO photoDTO = new() { Url= returnPath };
                return CreateActionResultInstance(ResponseDTO<PhotoDTO>.Success(photoDTO,200));
            }
            return CreateActionResultInstance(ResponseDTO<PhotoDTO>.Fail("Hata oluştu!", 400));
        }
    }
}
