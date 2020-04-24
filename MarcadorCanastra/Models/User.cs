using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MarcadorCanastra.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }



        
    }
}
