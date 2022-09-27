using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Models.DTO;
using NZWEBAPI.Repositories;

namespace NZWEBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository rep;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await rep.GetAllAsync();

            var walkDTO= mapper.Map<List<Models.DTO.WalksDTO>>(walks);

            return Ok(walkDTO);

        }
        [HttpGet("{Id :Guid}")]
        public async Task<IActionResult> GetWalkById(Guid Id)
        {
            var walks = await rep.GetWalkByIdAsync(Id);

            var walkDTO = mapper.Map<Models.DTO.WalksDTO>(walks);

            return Ok(walkDTO);

        }

        [HttpPost]

        public async Task<IActionResult>AddWalkDetails([FromBody]Models.DTO.WalksRequestDTO walk)
        {
            if (walk == null)
            {
                return BadRequest(ModelState);
            }

            var walkObj = mapper.Map<Models.Domain.Walk>(walk);

            var walkDTO = await rep.AddWalkAsync(walkObj);

            return Ok(walkDTO);

            
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateWalkDetails([FromRoute] Guid Id,[FromBody] WalksRequestDTO walksDTO)
        {

            if (walksDTO == null)
            {
                return BadRequest(ModelState);
            }

            var obj = mapper.Map<Models.Domain.Walk>(walksDTO);
            var objDto= await rep.UpdateWalkAsync(Id, obj);
            return Ok(objDto);


        }


        [HttpDelete]

        public async Task<IActionResult> DeleteWalkDetails(Guid Id)
        {
            var obj= await rep.DeleteWalkAsync(Id);
            if(obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }
    }
}
