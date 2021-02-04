using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbeTeamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPlayerPage : ContentPage
    {
        private Player player;

        public EditPlayerPage(Player player)
        {
            InitializeComponent();
            this.player = player;
            FillFields(player);
        }

        private void FillFields(Player player)
        {
            EntryShirtNumber.Text = player.ShirtNumber.ToString();
            EntryName.Text = player.Name;
            EntryNickname.Text = player.Nickname ?? "";
            EntryCpf.Text = player.Cpf ?? "";
            EntryIDNumber.Text = player.IDNumber ?? "";
            EntryDateOfBirth.Text = player.DateOfBirth.ToString();
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            int shirtNumber = 0;
            if (!int.TryParse(EntryShirtNumber.Text, out shirtNumber))
            {
                await DisplayAlert("Número inválido", "Por favor, informe um número", "OK");
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

            player.ShirtNumber = shirtNumber;
            player.Name = name;
            player.Nickname = nickname;
            player.Cpf = cpf;
            player.IDNumber = rg;
            player.DateOfBirth = dateOfBirth;

            await App.Service.UpdatePlayerAsync(player);
            await Navigation.PopModalAsync(true);
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}