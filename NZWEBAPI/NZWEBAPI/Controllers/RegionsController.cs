using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Models.Domain;
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
    }
}
