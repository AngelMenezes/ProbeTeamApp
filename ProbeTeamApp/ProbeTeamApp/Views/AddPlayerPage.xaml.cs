using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbeTeamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlayerPage : ContentPage
    {
        public AddPlayerPage()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            int shirtNumber = 0;
            if (!int.TryParse(EntryShirtNumber.Text, out shirtNumber))
                {
                await DisplayAlert("Número inválido", "Por favor, informe um número","OK");
                return;
            }
            var name = EntryName.Text;
            var nickname = EntryNickname.Text;
            var cpf = EntryCpf.Text;
            var rg = EntryIDNumber.Text;
            DateTime dateOfBirth = DateTime.Today;
            if (!DateTime.TryParse(EntryDateOfBirth.Text, out dateOfBirth))
            {
                await DisplayAlert("Data inválida", "Por favor, informe uma data", "OK");
                return;
            }

            var player = new Player
            {
                ShirtNumber = shirtNumber,
                Name = name,
                Nickname = nickname,
                Cpf = cpf,
                IDNumber = rg,
                DateOfBirth = dateOfBirth
            };

            //await App.Service.AddPlayerAsync(player);
            await App.AppService.AddPlayerAsync(player);
            await Navigation.PopModalAsync(true);
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}