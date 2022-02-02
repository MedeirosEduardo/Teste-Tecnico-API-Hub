using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Domain;
using UrnaEletronica.Interface;

namespace UrnaEletronica.Repository
{
    public class VoteRepository : IVoteRepository
    {
        private readonly ApplicationDbContext DbContext;
        public VoteRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> RegisterVote(int idCandidate)
        {
            try
            {
                var entity = new Vote()
                {                    
                    IdCandidate = idCandidate,
                    VoteDate = DateTime.Today,
                };

                await DbContext.Votes.AddAsync(entity);
                await DbContext.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
