using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CabraBoaApp.forms.Configuracoes;

namespace CabraBoaApp.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageConfiguracoes : ContentPage
	{
		public PageConfiguracoes ()
		{
			InitializeComponent ();
            ListView.ItemsSource = new List<MenuConfiguracoes>
            {
                new MenuConfiguracoes { Nome = "Usuário" },
                new MenuConfiguracoes { Nome = "Sincronização de Dados" },
                new MenuConfiguracoes { Nome = "Alertas" }

            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as MenuConfiguracoes;
            switch (menu.Nome)
            {
                case "Usuário":
                    await Navigation.PushAsync(new FormUsuario());
                    break;
                case "Sincronização de Dados":
                    await Navigation.PushAsync(new FormSincronizacao());
                    break;
                case "Alertas":
                    await Navigation.PushAsync(new FormAlertas());
                    break;                
                default:
                    await DisplayAlert("Itens", "Item não tratado!", "NOK");
                    break;
            }
        }
    }

    public class MenuConfiguracoes
    {
        public string Nome { get; set; }
    }
}