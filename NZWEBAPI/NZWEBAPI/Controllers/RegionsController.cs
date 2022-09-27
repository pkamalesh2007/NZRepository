using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Models.DTO;
using NZWEBAPI.Repositories;

namespace NZWEBAPI.Controllers
{
    [ApiController]
    //[Route("Regions")]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository rep;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await rep.GetAllAsync();

            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code= region.Code,
            //        Area=  region.Area,
            //        Lat= region.Lat,
            //        Long= region.Long,
            //        Population= region.Population

            //    };
            //    regionsDTO.Add(regionDTO);

            //});
           var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet("GetByRegionByIdAsync/{Id :Guid}")]
        public async Task<IActionResult> GetByRegionByIdAsync(Guid Id)
        {

            var region = await rep.GetAsync(Id);

            var regionsDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionsDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequest addRegionRequest)
        {
            if (addRegionRequest == null)
            {
                return BadRequest(ModelState);
            }

            var regionObj = mapper.Map<Models.Domain.Region>(addRegionRequest);

            var regionsDTO = await rep.AddAsync(regionObj);           

            return CreatedAtAction("GetByRegionByIdAsync", new { Id = regionsDTO.Id }, regionsDTO);

        }
        [HttpDelete("DeleteRegionAsync/{Id :Guid}")]
        public async Task<IActionResult> DeleteRegionAsync (Guid Id)
        {
            
            var Obj = await rep.DeleteAsync(Id);

            if (Obj == null)
            {
                return NotFound();
            }
            return Ok(Obj);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid Id,[FromBody] UpdateRegionRequest updateRegionRequest)
        {
            if (updateRegionRequest == null)
            {
                return BadRequest(ModelState);
            }
            var obj= mapper.Map<Models.Domain.Region>(updateRegionRequest);

           var objDto= await rep.UpdateAsync(Id, obj);

            return Ok(objDto);

        }

    }
}
