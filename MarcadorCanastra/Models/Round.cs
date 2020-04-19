using System;
using System.Collections.Generic;
using System.Linq;

namespace MarcadorCanastra.Models
{
    public class Round
    {
        public int RoundNumber { get; set; }
        public UserScore Player1Score { get; set; }
        public UserScore Player2Score { get; set; }
        public Game Game { get; set; }


    }
}
