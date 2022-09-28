﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Repositories;

namespace NZWEBAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository rep;
        private readonly IMapper mapper;

        public WalksDifficultyController(IWalkDifficultyRepository rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {

            var walksDifficulties= await rep.GetAllWalkDiffultiesAsync();
            var walksDifficultiesDTO = mapper.Map<List<Models.DTO.WalkDifficultyDTO>>(walksDifficulties);
            return Ok(walksDifficultiesDTO);


        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult>GetWalkDifficultyByIdAsync(Guid Id)
        {
            var walksDifficulty = await rep.GetWalkDifficultyByIdAsync(Id);
            var walksDifficultyDTO = mapper.Map<Models.DTO.WalkDifficultyDTO>(walksDifficulty);
            return Ok(walksDifficultyDTO);


        }

        [HttpPost]

        public async Task<IActionResult>CreatWalkDifficultyAsync(Models.DTO.WalkDifficultyDTO walkDifficultyDTO)
        {
            if(walkDifficultyDTO == null)
            {
                return BadRequest(ModelState);
            }

            var addWalkDifficulty= mapper.Map<Models.Domain.WalkDifficulty>(walkDifficultyDTO);

            var addwalkDifficultyDTO = await rep.CreateWalkDifficultyAsync(addWalkDifficulty);

            return Ok(addwalkDifficultyDTO);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult>UpdateWalkDifficulty([FromRoute]Guid Id,[FromBody]Models.DTO.WalkDifficultyDTO walkDifficultyDTO)
        {
            if(walkDifficultyDTO == null)
            {
                return BadRequest();
            }

            var updateWalkDifficulty= mapper.Map<Models.Domain.WalkDifficulty>(walkDifficultyDTO);

            var updateWalkDifficultyDTO = await rep.UpdateWalkDifficultyAsync(Id, updateWalkDifficulty);

            return Ok(updateWalkDifficultyDTO);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteWalkDifficulty(Guid Id)
        {
            var deleteWalkDifficulty = await rep.DeleteWalkDifficultyAsync(Id);

            if (deleteWalkDifficulty == null)
            {
                return NotFound();
            }

            return Ok(deleteWalkDifficulty);
        }

    }
}
