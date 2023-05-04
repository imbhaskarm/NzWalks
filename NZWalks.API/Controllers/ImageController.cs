using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }
        

        //Post:/api/images/Upload
       
        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if(ModelState.IsValid)
            {

                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),//BECAUSE of this function we did not use mapper
                    FileSizeInBytes = request.File.Length,
                    FileName = request.File.FileName,
                    FileDescription = request.FileDescription,

                };
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }

            //User repository to upload image
           

            return BadRequest(ModelState);
        } 

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtension.Contains(Path.GetExtension(request.File.FileName))) {
                ModelState.AddModelError("file", "Unsupported file extension");

            }

            if(request.File.Length >10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB,please upload a smaller size file.");
            }

        }
    }
}
