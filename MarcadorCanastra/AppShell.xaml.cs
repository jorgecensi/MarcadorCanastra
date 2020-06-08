using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MarcadorCanastra
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        public ICommand ShareUriCommand => new Command(async () => await ShareUri());

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }


        public async Task ShareUri()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://play.google.com/store/apps/details?id=com.jorgecensi.marcadorcanastra",
                Title = "Compartilhe este app",
                Subject = "Marcador de Canastra",
                Text = "Olha que legal este Marcador de Canastra"

            });
        }
    }
}

