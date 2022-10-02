using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await rep.GetAllAsync();

            
           var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet("GetByRegionByIdAsync/{Id :Guid}")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetByRegionByIdAsync(Guid Id)
        {

            var region = await rep.GetAsync(Id);

            var regionsDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionsDTO);
        }
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync([FromBody] AddRegionRequest addRegionRequest)
        {

            //if(!ValidateAddRegionAsync(addRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            var regionObj = mapper.Map<Models.Domain.Region>(addRegionRequest);

            var regionsDTO = await rep.AddRegionAsync(regionObj);

            return Ok(regionsDTO);


        }
        [HttpDelete("DeleteRegionAsync/{Id :Guid}")]
        [Authorize(Roles = "writer")]
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
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid Id,[FromBody] UpdateRegionRequest updateRegionRequest)
        {
            

            //if (!ValidateUpdateRegionAsync(updateRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            var obj= mapper.Map<Models.Domain.Region>(updateRegionRequest);

           var objDto= await rep.UpdateAsync(Id, obj);

            return Ok(objDto);

        }

        #region private Methods
        

        //private bool ValidateAddRegionAsync(AddRegionRequest addRegionRequest)
        //{
        //    if(addRegionRequest==null)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest), $"Add data to Region is required");
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(addRegionRequest.Code))
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Code), $"{nameof(addRegionRequest.Code)} cannot be null or empty or have whitespaces");
                
        //    }

        //    if (string.IsNullOrWhiteSpace(addRegionRequest.Name))
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Name), $"{nameof(addRegionRequest.Name)} cannot be null or empty or have whitespaces");
        //    }

        //    if(addRegionRequest.Area <=0)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Area), $"{nameof(addRegionRequest.Area)} cannot be less than or equal to zero");
        //    }

        //    if (addRegionRequest.Long <= 0)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Long), $"{nameof(addRegionRequest.Long)} cannot be less than or equal to zero");
        //    }

        //    if (addRegionRequest.Lat <= 0)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Lat), $"{nameof(addRegionRequest.Lat)} cannot be less than or equal to zero");
        //    }

        //    if (addRegionRequest.Population < 0)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Population), $"{nameof(addRegionRequest.Population)} cannot be less than zero");
        //    }

        //    if(ModelState.ErrorCount >0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        
        //private bool ValidateUpdateRegionAsync(UpdateRegionRequest updateRegionRequest)
        //{
        //    if (updateRegionRequest == null)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest), $"Add data to Region is required");
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(updateRegionRequest.Code))
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Code), $"{nameof(updateRegionRequest.Code)} cannot be null or empty or have whitespaces");

        //    }

        //    if (string.IsNullOrWhiteSpace(updateRegionRequest.Name))
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Name), $"{nameof(updateRegionRequest.Name)} cannot be null or empty or have whitespaces");
        //    }

        //    if (updateRegionRequest.Area <= 0)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Area), $"{nameof(updateRegionRequest.Area)} cannot be less than or equal to zero");
        //    }

        //    if (updateRegionRequest.Long <= 0)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Long), $"{nameof(updateRegionRequest.Long)} cannot be less than or equal to zero");
        //    }

        //    if (updateRegionRequest.Lat <= 0)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Lat), $"{nameof(updateRegionRequest.Lat)} cannot be less than or equal to zero");
        //    }

        //    if (updateRegionRequest.Population < 0)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Population), $"{nameof(updateRegionRequest.Population)} cannot be less than zero");
        //    }

        //    if (ModelState.ErrorCount > 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        #endregion
    }
}
