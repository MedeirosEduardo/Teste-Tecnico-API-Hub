using System;
using System.ComponentModel.DataAnnotations;

namespace UrnaEletronica.Domain
{
    public class Vote
    {
        public int IdVote { get; set; }
        public int IdCandidate { get; set; }
        public DateTime VoteDate { get; set; }
    }
}
