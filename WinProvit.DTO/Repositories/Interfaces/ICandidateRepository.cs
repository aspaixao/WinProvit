using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinProvit.Entities;

namespace WinProvit.DTO.Repositories.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateOutput>> GetCandidatesAsync();

        Task<CandidateOutput> GetCandidateAsync(Guid id);

        Task<CandidateOutput> AddAsync(CandidateInput candidate);

        Task<CandidateOutput> UpdateAsync(Guid id, CandidateInput candidate);

        Task<bool> DeleteAsynnc(Guid id);
    }
}
