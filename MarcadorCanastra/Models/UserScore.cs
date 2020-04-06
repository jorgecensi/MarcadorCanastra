﻿namespace MarcadorCanastra.Models
{
    public class UserScore
    {
        public string Id { get; set; }
        public int PlayerNumber { get; set; }
        public User User { get; set; }
        public int Total {
            get
            {
                return PontuacaoTotal();
            }
            internal set { } }
        public bool IsBatida { get; set; }
        public int TotalCanastraLimpa { get; set; }
        public int TotalCanastraSuja { get; set; }
        public int TotalCardsInHand { get; set; }

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
            return PontosTotalCanastraLimpa() + PontosTotalCanastraSuja() + PontosTotalCardsLessCardsInHand() + PontosBatida();
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
            return TotalCardsInHand * 10;
        }
        public int PontosBatida()
        {
            if (IsBatida)
            {
                return 100;
            }
            return 0;
        }
    }
}
