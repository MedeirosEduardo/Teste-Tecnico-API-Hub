using System.Threading.Tasks;
using UrnaEletronica.Domain;

namespace UrnaEletronica.Interface
{
    public interface IVoteRepository
    {
        Task<int> RegisterVote(int partyLegend);
    }
}
