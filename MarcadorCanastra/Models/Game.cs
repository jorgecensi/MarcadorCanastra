using System;
using System.Collections.Generic;
using System.Linq;

namespace MarcadorCanastra.Models
{
    public class Game
    {
        public string Id { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public List<Round> Rounds { get; set; } = new List<Round>();
        public int FinalScorePlayer1
        {
            get
            {
                return Rounds.Sum(x => x.Player1Score?.Total??0) ;
            }
        }
        public int FinalScorePlayer2
        {
            get
            {
                return Rounds.Sum(x => x.Player2Score?.Total??0);
            }
        }

        public DateTime Date { get; set; }

        public Game()
        {

        }
        public Game(User player1, User player2)
        {
            Id = Guid.NewGuid().ToString();
            Player1 = player1;
            Player2 = player2;
            Date = DateTime.Now;
        }

        

        public void AddRound(Round round)
        {
            Rounds.Add(round);

            

        }


    }

}
