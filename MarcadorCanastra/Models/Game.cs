using System;
using System.Collections.Generic;

namespace MarcadorCanastra.Models
{
    public class Game
    {
        public string Id { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<UserScore> Scores { get; set; } = new List<UserScore>();
        public DateTime Date { get; set; }

        public Game(List<User> users)
        {
            Users = users;
            Date = DateTime.Now;
        }
    }

}
