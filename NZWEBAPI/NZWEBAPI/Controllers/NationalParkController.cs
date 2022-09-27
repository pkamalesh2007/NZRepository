using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Models.DTO;
using NZWEBAPI.Repositories;

namespace NZWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository rep;
        private readonly IMapper mapper;

        public NationalParkController(INationalParkRepository rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllNationalParks()
        {
            var nationalParks = rep.GetNationalParks();

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
            var nationalParksDTO = mapper.Map<List<Models.DTO.NationalParkDTO>>(nationalParks);
            return Ok(nationalParksDTO);
        }

        [HttpGet("GetNationalPark/{Id :int}")]
        public IActionResult GetNationalPark(int Id)
        {
            var nationalPark = rep.GetNationalPark(Id);
            if(nationalPark == null)
            {
                return NotFound();
            }

            var nationalParksDTO = mapper.Map<Models.DTO.NationalParkDTO>(nationalPark);



            return Ok(nationalParksDTO);

        }

        [Route("")]
        [HttpPost]
        
        public  IActionResult CreateNationalPark([FromBody] NationalParkDTO nationalParkDTO)
        {
            if(nationalParkDTO == null)
            {
                return  BadRequest(ModelState);
            }

            if(rep.NationalParkExists(nationalParkDTO.Name))
            {
                ModelState.AddModelError("", "NationalPark Exists");
                return  StatusCode(404, ModelState);

            }

            
            var nationalParkObj=  mapper.Map<Models.Domain.NationalPark>(nationalParkDTO);

            if(!rep.CreateNationalParks(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong while saving the record {nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(GetNationalPark), new { Id = nationalParkObj.Id }, nationalParkObj);

        }

        [HttpDelete("DeleteNationalPark/{Id :int}")]
        
        public IActionResult DeleteNationalPark(int Id)
        {
            if(!rep.NationalParkExists(Id))
            {
                ModelState.AddModelError("", "NationalPark does not Exists");
                return StatusCode(404, ModelState);

            }

            var Obj = rep.GetNationalPark(Id);
            if (!rep.DeleteNationalPark(Obj))
            {
                ModelState.AddModelError("", $"Something went wrong while Deleting the record {Obj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

         }

        [HttpPatch("UpdateNationalPark/{Id :int}")]
        public IActionResult UpdateNationalPark(int Id, [FromBody] NationalParkDTO nationalParkDTO)
        {
            if(nationalParkDTO == null ||Id!=nationalParkDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var obj=mapper.Map<NationalPark>(nationalParkDTO);

            
            if (!rep.UpdateNationalPark(obj))
            {
                ModelState.AddModelError("", $"Something went wrong while Updating the record {obj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
