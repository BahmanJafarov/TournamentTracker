using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        public int TeamCompetingId { get; set; }
        public TeamModel TeamCompeting { get; set; }
        public double Score { get; set; }
        /// <summary>
        /// The unique identifier for the parent matchup (team)
        /// </summary>
        public int ParentMatchupId { get; set; }
        public MatchupModel ParentMatchup { get; set; }
    }
}
