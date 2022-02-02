using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Domain;
using UrnaEletronica.Interface;

namespace UrnaEletronica.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext DbContext;
        public CandidateRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public bool CheckIfItIsRegistered(string fullName, int partyLegend)
        {
            if (!DbContext.Candidates.Any(x => x.FullName.ToUpper() == (fullName.ToUpper()) || x.PartyLegend == partyLegend))
                return false;

            else
                return true;
        }
        public async Task<bool> CheckIfItIsRegistered(int partyLegend)
        {
            var entity = DbContext.Candidates
                .Where(x => x.PartyLegend == partyLegend);

            if (entity is null)            
                return false;
            
            else            
                return true;            
        }

        public async Task<int> DeleteCandidate(int partyLegend)
        {
            var entity = DbContext.Candidates
                .Where(x => x.PartyLegend == partyLegend).FirstOrDefault();

            try
            {
                if(entity != null)
                {
                    DbContext.Candidates.Remove(entity);
                    await DbContext.SaveChangesAsync();
                    return 1;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<Candidate> RegistreVoteAndGetCandidate(int partyLegend)
        {
            var entity = DbContext.Candidates
                .Where(x => x.PartyLegend == partyLegend).FirstOrDefault();
            try
            {
                entity.Votes++;
                DbContext.Candidates.Update(entity);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception e) 
            {
                return entity;
            }

            return entity;

        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            var entities = DbContext.Candidates
                .OrderByDescending(x => x.Votes)
                .ToList();

            return entities;
        }

        public Candidate GetMostVotedCandidate()
        {
            var entity = DbContext.Candidates
                .OrderByDescending(x => x.Votes)
                .FirstOrDefault();

            return entity;
        }
        public Candidate GetCandidateByPartyLegend(int partyLegend)
        {
            return DbContext.Candidates.Where(x => x.PartyLegend == partyLegend).FirstOrDefault();
        }

        public async Task<int> SaveNewCandidate(CandidateDTO model)
        {
            try
            {
                var entity = new Candidate()
                {
                    FullName = model.FullName,
                    VicesName = model.VicesName,
                    RegistreDate = DateTime.Today,
                    PartyLegend = model.PartyLegend,
                    Votes = 0
                };

                await DbContext.Candidates.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                return 1;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
