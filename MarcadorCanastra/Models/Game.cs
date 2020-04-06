using System;
using System.Collections.Generic;
using System.Linq;

namespace MarcadorCanastra.Models
{
    public class Game
    {
        public string Id { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Round> Rounds { get; set; } = new List<Round>();
        public int FinalScorePlayer1
        {
            get
            {
                return Rounds.Sum(x => x.Player1Score);
            }
        }
        public int FinalScorePlayer2
        {
            get
            {
                return Rounds.Sum(x => x.Player2Score);
            }
        }

        public DateTime Date { get; set; }

        public Game()
        {

        }
        public Game(List<User> users)
        {
            Users = users;
            Date = DateTime.Now;
        }
    }

}
