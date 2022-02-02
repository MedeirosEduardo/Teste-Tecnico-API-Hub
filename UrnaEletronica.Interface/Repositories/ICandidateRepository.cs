using System.Collections.Generic;
using System.Threading.Tasks;
using UrnaEletronica.Domain;

namespace UrnaEletronica.Interface
{
    public interface ICandidateRepository
    {
        bool CheckIfItIsRegistered(string fullName, int partyLegend);
        Task<bool> CheckIfItIsRegistered(int partyLegend);
        Task<Candidate> RegistreVoteAndGetCandidate(int partyLegend);
        Task<List<Candidate>> GetAllCandidates();
        Candidate GetCandidateByPartyLegend(int partyLegend);
        Task<int> SaveNewCandidate(CandidateDTO model);
        Task<int> DeleteCandidate(int partyLegend);
    }
}
