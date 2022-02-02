using System;
using System.Collections.Generic;

namespace UrnaEletronica.Domain
{
    public class Candidate
    {
        public int IdCandidate { get; set; }
        public string FullName { get; set; }
        public string? VicesName { get; set; }
        public DateTime RegistreDate { get; set; }
        public int PartyLegend { get; set; }
        public int Votes { get; set; }
    }
}
