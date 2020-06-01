using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Xamarin.Essentials;

namespace MarcadorCanastra.Models
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(User))]
        public int Player1Id { get; set; }
        [OneToOne("Player1Id", CascadeOperations = CascadeOperation.All)]
        public User Player1 { get; set; }

        [ForeignKey(typeof(User))]
        public int Player2Id { get; set; }
        [OneToOne("Player2Id", CascadeOperations = CascadeOperation.All)]
        public User Player2 { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
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
            
            Player1 = player1;
            Player2 = player2;
            Date = DateTime.Now;
        }

        

        public void AddRound(Round round)
        {
            Rounds.Add(round);

            

        }

        public bool GameEnded {
            get
            {
                var result = false;
                if (Preferences.Get("MaxPoints", 0) != 0)
                {
                    var maxPoints = Preferences.Get("MaxPoints", 0);
                    if (FinalScorePlayer1 >= maxPoints || FinalScorePlayer2 >= maxPoints)
                    {
                        result =  true;
                    }

                }
                return result;
            }
        }

        public string Winner {
            get
            {
                return FinalScorePlayer1 > FinalScorePlayer2 ? Player1.Name : Player2.Name;                
            }
        }


    }

}
