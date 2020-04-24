using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MarcadorCanastra.Models
{
    public class Round
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Game))]
        public int GameId { get; set; }
        [ManyToOne]
        public Game Game { get; set; }

        public int RoundNumber { get; set; }

        [ForeignKey(typeof(UserScore))]
        public int Player1ScoreId { get; set; }
        [OneToOne("Player1ScoreId",CascadeOperations = CascadeOperation.All)]
        public UserScore Player1Score { get; set; }

        [ForeignKey(typeof(UserScore))]
        public int Player2ScoreId { get; set; }
        [OneToOne("Player2ScoreId", CascadeOperations = CascadeOperation.All)]
        public UserScore Player2Score { get; set; }
        


    }
}
