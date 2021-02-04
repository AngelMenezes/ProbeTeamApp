using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbeTeamApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListPlayers();
        }

        public void ListPlayers()
        {
            var players = App.AppService.GetAllPlayers();

            if(players == null || players.Count() == 0)
            {
                DisplayAlert("Erro ao Tentar obter as Jogadoras", "Não foi possível obter as Jogadoras disponíveis, tente novamente mais tarde!", "Ok");
                return;
            }

            FlexLayoutPlayers.Children.Clear();

            foreach (var player in players)
            {
                var playerStackLayout = new StackLayout();
                playerStackLayout.WidthRequest = 200;
                playerStackLayout.HeightRequest = 300;

                var image = new ImageButton();
                image.HorizontalOptions = LayoutOptions.Center;
                image.Source = ImageSource.FromUri(new Uri("https://lh3.googleusercontent.com/6iVxvWL1ViUb_6HpcPJNSbVVrKDgWhmWmynZ6GZo9sKKxsQ1GINq2ar8kpBMpvTu88trwo6sx_L59cYeuIh39W0ynuWV50htaEHQCfSaiBZ2bwTmqV_6uT72x0yVT9reLQsZNfIeszLCtxPtJbSj-N5T38fQ6m0LupgIuO2ZmHBcqUH-ZyIH0TxwrkHDZQNIg48Q3AYqBrBTIb0bS8nfk7bvv8rlm8EUeZk1iY0hPXUiJVYaqXcd_3M1FlQ3cHclXct9GfTowNOMhr4LHG4GsXn1EEbIp7muT8UHLUjsxNgyY9INGEh0_RcBxoJTg0BcR00sGtTgGW1rkyOCr9WZcRSWgI4jDKIpdTZB1v8nVpnsldyIqzOpjosL2UPDOmILqF7vxvFmqAuCzHFtIFN3Jeuis4OzhcDXhOiKgUiHrDig4d5U5dhognd3snkP7UCNX4lLO-f4-8AK0gSWbTpplVXTZItZlqSs029yUJ4zzb1w_0xq5Ms2k5WvDKy7P3g63etWm0mOtjRnyTMblu3VwgO9__DM-fAn-zqZ0191ccTzaDKG32FbzroOtN999SVDpfcf2VCzDrQTT2YyX707h4coXl_3LDrHA3YDnzWk8fjL5SHQ2XQ_zG45GmfqQ83MPZzozLvxfoMuY_HHPfLG3WoTiARU8haxSPvqlLbvDcEiP8qgdGrozrl77WTuCQ=s256-no?authuser=1"));
                
                playerStackLayout.Children.Add(image);

                var labelName = new Label();
                labelName.HorizontalOptions = LayoutOptions.CenterAndExpand;
                labelName.VerticalOptions = LayoutOptions.CenterAndExpand;
                labelName.Text = player.Name;

                playerStackLayout.Children.Add(labelName);

                var labelNickname = new Label();
                labelNickname.HorizontalOptions = LayoutOptions.CenterAndExpand;
                labelNickname.VerticalOptions = LayoutOptions.CenterAndExpand;
                labelNickname.Text = player.Nickname;

                playerStackLayout.Children.Add(labelNickname);

                var labelShirtNumber = new Label();
                labelShirtNumber.HorizontalOptions = LayoutOptions.CenterAndExpand;
                labelShirtNumber.VerticalOptions = LayoutOptions.CenterAndExpand;
                labelShirtNumber.Text = player.ShirtNumber.ToString();
               
                playerStackLayout.Children.Add(labelShirtNumber);

                FlexLayoutPlayers.Children.Add(playerStackLayout);
            }
        }

        private void BtnAddPlayer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPlayerPage(), true);
            //Navigation.InsertPageBefore(new AddPlayerPage(), this);
            //Navigation.PopAsync().ConfigureAwait(false);
        }

        //private async Task AddPlayerAsync(Player player)
        //{
        //    await App.AppService.AddPlayerAsync(player);
        //    await DisplayAlert("Jogadora adicionada", "Sua Jogadora foi adicionada! Isso não significa que ela foi confirmada.", "OK");
        //} 


    }
}