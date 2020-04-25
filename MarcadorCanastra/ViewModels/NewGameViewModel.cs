using System;
using MarcadorCanastra.Models;
using MarcadorCanastra.Services;

namespace MarcadorCanastra.ViewModels
{
    public class NewGameViewModel
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }

        public NewGameViewModel(Game lastGame)
        {
            if (lastGame != null)
            {
                Player1Name = lastGame.Player1.Name;
                Player2Name = lastGame.Player2.Name;

            }

        }
    }
}
