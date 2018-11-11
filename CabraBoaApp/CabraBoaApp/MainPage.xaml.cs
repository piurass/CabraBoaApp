using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CabraBoaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnTappedCrescimento(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PageCrescimento());
        }

        void OnTappedReproducao(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PageReproducao());
        }

        void OnTappedCadastro(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PageCadastro());
        }

        void OnTappedTarefas(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PageTarefas());
        }

        void OnTappedAlertas(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PageAlertas());
        }

        void OnTappedConfiguracoes(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PageConfiguracoes());
        }
    }
}
