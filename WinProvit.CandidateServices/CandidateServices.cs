using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinProvit.Core.Interfaces;
using WinProvit.DTO;
using WinProvit.Entities;

namespace WinProvit.CandidateServices
{
    public class CandidateServices : ICandidateServices
    {
        public CandidateServices(WPContext context)
        {
            Context = context;
        }

        public WPContext Context { get; }

        public async Task<CandidateOutput> AddAsync(CandidateInput candidate)
        {
            var candidateFounded = await Context.Candidates.AnyAsync(x => x.Email == candidate.Email);
            if (candidateFounded)
            {
                return null;
            }

            //Usar mapper aqui
            var newCandidate = new Candidate()
            {
                Name = candidate.Name,
                Email = candidate.Email,
                Phone = candidate.Phone,
                Address = candidate.Address
            };

            await Context.Candidates.AddAsync(newCandidate);
            await Context.SaveChangesAsync();

            //Mapper
            return MapCandidate(newCandidate);
        }

        public async Task<bool> DeleteAsynnc(Guid id)
        {
            var candidateFounded = await Context.Candidates.FindAsync(id);

            if(candidateFounded != null)
            {
                Context.Candidates.Remove(candidateFounded);
                await Context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<CandidateOutput> GetCandidateAsync(Guid id)
        {
            var candidateFounded = await Context.Candidates.FindAsync(id);
            if (candidateFounded != null)
                return MapCandidate(candidateFounded);

            return null;
        }

        public async Task<IEnumerable<CandidateOutput>> GetCandidatesAsync()
        {
            var candidates = await Context.Candidates.AsNoTracking().ToListAsync();
            
            if (candidates.Count == 0) return Enumerable.Empty<CandidateOutput>().ToList();

            var result = new List<CandidateOutput>();
            foreach(var c in candidates)
            {
                result.Add(MapCandidate(c));
            }

            return result;
        }

        public async Task<CandidateOutput> UpdateAsync(Guid id, CandidateInput candidate)
        {
            var candidateFounded = await Context.Candidates.FindAsync(id);

            if (candidateFounded != null)
            {
                var candidateChange = new Candidate() { Id = id, Name = candidate.Name, Email = candidate.Email, Phone = candidate.Phone, Address = candidate.Address };
                Context.Entry(candidateFounded).CurrentValues.SetValues(candidateChange);

                await Context.SaveChangesAsync();

                return MapCandidate(candidateFounded);
            }

            return null;
        }

        private CandidateOutput MapCandidate(Candidate input)
        {
            return new CandidateOutput()
            {
                Id = input.Id,
                Name = input.Name,
                Phone = input.Phone,
                Address = input.Address,
                Email = input.Email
            };
        }
    }
}
