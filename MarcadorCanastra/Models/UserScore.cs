using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MarcadorCanastra.Models
{
    public class UserScore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PlayerNumber { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public User User { get; set; }


        //[ForeignKey(typeof(Round))]
        //public int RoundId { get; set; }
        //[ManyToOne]
        //public Round Round { get; set; }


        public int Total
        {
            get
            {
                return PontuacaoTotal();
            }
            internal set { }
        }
        public bool IsBatida { get; set; }
        public bool SemMorto { get; set; }
        public int TotalCanastraLimpa { get; set; }
        public int TotalCanastraSuja { get; set; }
        public int? TotalCardsInHand { get; set; }


        public UserScore()
        {

        }
        public UserScore(User user)
        {

            User = user;
            Total = 0;
        }



        private int PontuacaoTotal()
        {
            return PontosTotalCanastraLimpa() +
                PontosTotalCanastraSuja() +
                PontosTotalCardsLessCardsInHand() +
                PontosBatida() +
                PontosSemMorto();
        }

        private int PontosTotalCanastraLimpa()
        {
            return TotalCanastraLimpa * 300;
        }
        private int PontosTotalCanastraSuja()
        {
            return TotalCanastraSuja * 200;
        }
        private int PontosTotalCardsLessCardsInHand()
        {
            var total = TotalCardsInHand ?? 0;
            return total;
        }
        public int PontosBatida()
        {
            if (IsBatida)
            {
                return 100;
            }
            return 0;
        }
        public int PontosSemMorto()
        {
            if (SemMorto)
            {
                return -100;
            }
            return 0;
        }
    }
}
