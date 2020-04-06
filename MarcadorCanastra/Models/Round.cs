using System;
using System.Collections.Generic;
using System.Linq;

namespace MarcadorCanastra.Models
{
    public class Round
    {
        public int RoundNumber { get; set; }
        public List<UserScore> Scores { get; set; } = new List<UserScore>();

        public int Player1Score
        {
            get 
            {
                return Scores.Single(x => x.PlayerNumber == 1).Total;
            }
        }
        public int Player2Score
        {
            get
            {
                return Scores.Single(x => x.PlayerNumber == 2).Total;
            }
        }

        public Round()
        {

        }
    }
}
