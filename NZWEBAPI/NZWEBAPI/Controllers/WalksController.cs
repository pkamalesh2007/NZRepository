
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Models.DTO;
using NZWEBAPI.Repositories;

namespace NZWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository rep;
        private readonly IMapper mapper;
        private readonly IRegionRepository regionRepository;
        private readonly IWalkDifficultyRepository walkDifficultyRepository;

        public WalksController(IWalkRepository rep,IMapper mapper,IRegionRepository regionRepository,IWalkDifficultyRepository walkDifficultyRepository)
        {
            this.rep = rep;
            this.mapper = mapper;
            this.regionRepository = regionRepository;
            this.walkDifficultyRepository = walkDifficultyRepository;
        }
        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await rep.GetAllAsync();

            var walkDTO= mapper.Map<List<Models.DTO.WalksDTO>>(walks);

            return Ok(walkDTO);

        }
        [HttpGet("{Id :Guid}")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkById(Guid Id)
        {
            var walks = await rep.GetWalkByIdAsync(Id);

            var walkDTO = mapper.Map<Models.DTO.WalksDTO>(walks);

            return Ok(walkDTO);

        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult>AddWalkDetailsAsync([FromBody] Models.DTO.WalksRequestDTO walk)
        {

            //if (!(await ValidateAddWalkDetails(walk)))
            //{
            //    return BadRequest(ModelState);
            //}

            var walkObj = mapper.Map<Models.Domain.Walk>(walk);

            var walkDTO = await rep.AddWalkAsync(walkObj);

            return Ok(walkDTO);

            
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateWalkDetailsAsync([FromRoute] Guid Id,[FromBody] WalksUpdateRequest walksUpdateRequest)
        {

            //if (!(await ValidateUpdateWalkDetails(walksUpdateRequest)))
            //{
            //    return BadRequest(ModelState);
            //}

            var obj = mapper.Map<Models.Domain.Walk>(walksUpdateRequest);
            var objDto= await rep.UpdateWalkAsync(Id, obj);
            return Ok(objDto);


        }


        [HttpDelete]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteWalkDetails(Guid Id)
        {
            var obj= await rep.DeleteWalkAsync(Id);
            if(obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        #region private method
        //private async Task<bool> ValidateAddWalkDetails(Models.DTO.WalksRequestDTO walk)
        //{
        //    if (walk == null)
        //    {
        //        ModelState.AddModelError(nameof(walk), $"Adding the walk details is required");
        //        return false;
        //    }

        //    //if(string.IsNullOrWhiteSpace(walk.Name))
        //    //{
        //    //    ModelState.AddModelError(nameof(walk.Name), $"{nameof(walk.Name)} cannot be null or empty or has white space");
        //    //}

        //    //if (walk.Length <=0)
        //    //{
        //    //    ModelState.AddModelError(nameof(walk.Length), $"{nameof(walk.Length)} cannot be less or equal to zero");
        //    //}

        //    var region= await regionRepository.GetAsync(walk.RegionId);
        //    if(region == null)
        //    {
        //        ModelState.AddModelError(nameof(walk.RegionId), $"{nameof(walk.RegionId)} does not exists");
        //    }
        //    var walkrepository = await walkDifficultyRepository.GetWalkDifficultyByIdAsync(walk.WalkDifficultyId);
        //    if(walkrepository == null)
        //    {
        //        ModelState.AddModelError(nameof(walk.WalkDifficultyId), $"{nameof(walk.WalkDifficultyId)} does not exists");
        //    }

        //    if(ModelState.ErrorCount >0)
        //    {
        //        return false;
        //    }

        //    return true;

        //}

        //private async Task<bool> ValidateUpdateWalkDetails(Models.DTO.WalksUpdateRequest walk)
        //{
        //    if (walk == null)
        //    {
        //        ModelState.AddModelError(nameof(walk), $"Adding the walk details is required");
        //        return false;
        //    }

        //    //if (string.IsNullOrWhiteSpace(walk.Name))
        //    //{
        //    //    ModelState.AddModelError(nameof(walk.Name), $"{nameof(walk.Name)} cannot be null or empty or has white space");
        //    //}

        //    //if (walk.Length <= 0)
        //    //{
        //    //    ModelState.AddModelError(nameof(walk.Length), $"{nameof(walk.Length)} cannot be less or equal to zero");
        //    //}

        //    var region = await regionRepository.GetAsync(walk.RegionId);
        //    if (region == null)
        //    {
        //        ModelState.AddModelError(nameof(walk.RegionId), $"{nameof(walk.RegionId)} does not exists");
        //    }
        //    var walkrepository = await walkDifficultyRepository.GetWalkDifficultyByIdAsync(walk.WalkDifficultyId);
        //    if (walkrepository == null)
        //    {
        //        ModelState.AddModelError(nameof(walk.WalkDifficultyId), $"{nameof(walk.WalkDifficultyId)} does not exists");
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
