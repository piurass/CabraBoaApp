using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CabraBoaApp.pages;

namespace CabraBoaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnTappedCrescimento(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PageCrescimento());
        }

        async void OnTappedReproducao(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PageReproducao());
        }

        async void OnTappedCadastro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PageCadastro());
        }

        async void OnTappedTarefas(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PageTarefas());
        }

        async void OnTappedAlertas(object sender, EventArgs args)
        {            
            await Navigation.PushAsync(new PageAlertas());
        }

        async void OnTappedConfiguracoes(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PageConfiguracoes());
        }
    }
}
