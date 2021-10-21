using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinProvit.Core.Interfaces;
using WinProvit.Entities;

namespace WinProvit.Api.Candidate.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        public ICandidateServices CandidateServices { get; }

        public CandidateController(ICandidateServices candidateServices)
        {
            CandidateServices = candidateServices;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateOutput>> Candidate()
        {
            return await CandidateServices.GetCandidatesAsync();
        }

        [HttpGet("{id}")]
        public async Task<dynamic> Candidate(Guid id)
        {
            var result = await CandidateServices.GetCandidateAsync(id);
            if (result == null)
                return NotFound(new { message = "Candidate not found" });
            else
                return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<dynamic> Candidate(CandidateInput candidate)
        {
            var result = await CandidateServices.AddAsync(candidate);
            if (result == null)
                return Ok(new { message = "This candidate not included" });

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<dynamic> UpdateAsync(Guid id, CandidateInput candidate)
        {
            var result = await CandidateServices.UpdateAsync(id, candidate);
            if (result == null)
                return Ok(new { message = "This candidate not update" });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<dynamic> DeleteAsync(Guid id)
        {
            var result = await CandidateServices.DeleteAsynnc(id);
            if (!result)
                return Ok(new { message = "Candidate not deleted" });

            return Ok();
        }

    }
}
