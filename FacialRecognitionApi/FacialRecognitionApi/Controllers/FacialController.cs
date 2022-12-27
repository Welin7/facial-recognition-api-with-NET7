using FacialRecognitionApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace FacialRecognitionApi.Controllers
{
    [Route("api/facial")]
    [ApiController]
    public class FacialController : ControllerBase
    {
        [HttpPost("recognize")]
        public async Task<IActionResult> RecognizeFacial(IFormFile file, [FromServices] IFacialRecognitionService service)
        {
            var result = await service.RecognizeFace(file);

            return Ok(new { faceFileName = result });
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetImageFacial([FromRoute] string fileName)
        {
            if (System.IO.File.Exists(fileName) is false)
                return NotFound();

            var bytes = await System.IO.File.ReadAllBytesAsync(fileName);
            return File(bytes, "image/jpeg");
        }
    }
}
