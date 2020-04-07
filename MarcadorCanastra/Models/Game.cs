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
                return Rounds.Sum(x => x.Player1Score.Total);
            }
        }
        public int FinalScorePlayer2
        {
            get
            {
                return Rounds.Sum(x => x.Player2Score.Total);
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

        public void AddScore(UserScore userScore)
        {

            var openRound = Rounds.Where(x => !x.IsClosed).FirstOrDefault();
            if (openRound == null)
            {
                var newRound = new Round();
                newRound.RoundNumber = Rounds.Count() + 1;

                if (userScore.PlayerNumber == 1)
                {
                    newRound.Player1Score = userScore;
                }
                else
                {
                    newRound.Player2Score = userScore;
                }

                Rounds.Add(newRound);
            }
            else
            {
                var roundToUpdate = Rounds
                    .Where(x => x.RoundNumber == openRound.RoundNumber)
                    .FirstOrDefault();
                if (userScore.PlayerNumber == 1)
                {
                    roundToUpdate.Player1Score = userScore;
                }
                else
                {
                    roundToUpdate.Player2Score = userScore;
                }


            }

        }

        
    }

}
