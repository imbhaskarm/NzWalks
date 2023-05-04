using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Data;
 
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

//based on the incoming request URL and HTTP verb (GET/POST/PUT/PATCH/DELETE), Web API decides which Web API controller and action method to execute e.g. 
//    Get() method will handle HTTP GET request, Post() method will handle HTTP POST request,
//    Put() mehtod will handle HTTP PUT request and Delete() method will handle HTTP DELETE request for the above Web API.

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 

    public class RegionsController : ControllerBase
    {
        //private readonly NZWalksDbContext dbContext;

        //public RegionsController(NZWalksDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        //[HttpGet]
        //public async  Task<IActionResult> GetAll()
        //{
        //    var regionsDomain = await dbContext.Regions.ToListAsync();

        //    //map domain models to dto

        //    var regionsDto = new List<RegionDto>();

        //    foreach (var regionDomain in regionsDomain)
        //    {

        //        regionsDto.Add(new RegionDto()
        //        {
        //            Id = regionDomain.Id,
        //            Code = regionDomain.Code,
        //            Name = regionDomain.Name,
        //            RegionImageUrl = regionDomain.RegionImageUrl,
        //        }
        //            );

        //    }
        //    return Ok(regionsDto);
        //}

        //[HttpGet]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid id)
        //{
        //    var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        //    if (regionDomain == null)
        //    {
        //        return NotFound();
        //    }

        //    var regionsDto = new RegionDto
        //    {

        //        Id = regionDomain.Id,
        //        Code = regionDomain.Code,
        //        Name = regionDomain.Name,
        //        RegionImageUrl = regionDomain.RegionImageUrl,
        //    };
        //    return Ok(regionsDto);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        //{
        //    var regionDomainModel = new Region
        //    {
        //        Code = addRegionRequestDto.Code,
        //        Name = addRegionRequestDto.Name,
        //        RegionImageUrl = addRegionRequestDto.RegionImageUrl

        //    };

        //   await dbContext.Regions.AddAsync(regionDomainModel);
        //   await dbContext.SaveChangesAsync();

        //    var regionDto = new RegionDto
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };
        //    return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        //}

        //[HttpPut]
        //[Route("{id:Guid}")]

        //public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        //{
        //    var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        //    if (regionDomainModel == null)
        //    {
        //        return NotFound();
        //    }
        //    //Map Dto to Domain Model

        //    regionDomainModel.Code = updateRegionRequestDto.Code;
        //    regionDomainModel.Name = updateRegionRequestDto.Name;
        //    regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

        //   await dbContext.SaveChangesAsync();

        //    var regionDto = new RegionDto
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };

        //    return Ok(regionDto);


        //}

        //[HttpDelete]

        //[Route("{id:Guid}")]


        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{

        //    var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        //    if (regionDomainModel == null)
        //    {
        //        return NotFound();
        //    }

        //    dbContext.Regions.Remove(regionDomainModel);
        //    await dbContext.SaveChanges();

        //    //return Deleted Region back
        //    // map Domain Model To DTO

        //    var regionDto = new RegionDto
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };


        //    return Ok(regionDto);

        //}

        //private readonly NZWalksDbContext dbContext;
        //private readonly IRegionRepository regionRepository;


        //public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository)
        //{
        //    this.dbContext = dbContext;
        //    this.regionRepository = regionRepository;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var regionsDomain = await regionRepository.GetAllAsync();

        //    //map domain models to dto

        //    var regionsDto = new List<RegionDto>();

        //    foreach (var regionDomain in regionsDomain)
        //    {

        //        regionsDto.Add(new RegionDto()
        //        {
        //            Id = regionDomain.Id,
        //            Code = regionDomain.Code,
        //            Name = regionDomain.Name,
        //            RegionImageUrl = regionDomain.RegionImageUrl,
        //        }
        //            );

        //    }
        //    return Ok(regionsDto);
        //}

        //[HttpGet]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid id)
        //{
        //    var regionDomain = await  regionRepository.GetByIdAsync(id);
        //    if (regionDomain == null)
        //    {
        //        return NotFound();
        //    }

        //    var regionsDto = new RegionDto
        //    {

        //        Id = regionDomain.Id,
        //        Code = regionDomain.Code,
        //        Name = regionDomain.Name,
        //        RegionImageUrl = regionDomain.RegionImageUrl,
        //    };
        //    return Ok(regionsDto);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        //{
        //    var regionDomainModel = new Region
        //    {
        //        Code = addRegionRequestDto.Code,
        //        Name = addRegionRequestDto.Name,
        //        RegionImageUrl = addRegionRequestDto.RegionImageUrl

        //    };

        //    regionDomainModel=await regionRepository.CreateAsync(regionDomainModel);//this will be populated back with Id


        //    var regionDto = new RegionDto
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };
        //    return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        //}

        //[HttpPut]
        //[Route("{id:Guid}")]

        //public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        //{
        //    var regionDomainModel = new Region
        //    {

        //        Code = updateRegionRequestDto.Code,
        //        Name = updateRegionRequestDto.Name,
        //        RegionImageUrl = updateRegionRequestDto.RegionImageUrl

        //    };

        //     regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
        //    if(regionDomainModel==null)
        //    {
        //        return null;
        //    }
        //    var regionDto = new RegionDto
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };

        //    return Ok(regionDto);


        //}

        //[HttpDelete]

        //[Route("{id:Guid}")]


        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{

        //    var regionDomainModel = await regionRepository.DeleteAsync(id);

        //    if (regionDomainModel == null)
        //    {
        //        return NotFound();
        //    }


        //    //return Deleted Region back
        //    // map Domain Model To DTO

        //    var regionDto = new RegionDto
        //    {
        //        Id = regionDomainModel.Id,
        //        Code = regionDomainModel.Code,
        //        Name = regionDomainModel.Name,
        //        RegionImageUrl = regionDomainModel.RegionImageUrl,
        //    };


        //    return Ok(regionDto);

        //}




        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();

            //map domain models to dto

            //var regionsDto = new List<RegionDto>();

            //foreach (var regionDomain in regionsDomain)
            //{

            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl,
            //    }
            //        );

            //}

           var regionsDto=mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //var regionsDto = new RegionDto
            //{

            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl,
            //};

           var regionsDto=mapper.Map<RegionDto>(regionDomain);
            return Ok(regionsDto);
        }


        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
           
                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDto.Code,
                //    Name = addRegionRequestDto.Name,
                //    RegionImageUrl = addRegionRequestDto.RegionImageUrl

                //};

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);//this will be populated back with Id

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);
                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl,
                //};
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
          
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //var regionDomainModel = new Region
            //{

            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl

            //};

            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            var regionDto=mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);


        }

        [HttpDelete]

        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer,Reader")]


        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }


            //return Deleted Region back
            // map Domain Model To DTO

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);


            return Ok(regionDto);

        }
       
    }
}

