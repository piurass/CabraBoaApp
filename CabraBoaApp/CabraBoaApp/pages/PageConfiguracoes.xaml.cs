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
                new MenuConfiguracoes { Nome = "Acesso Internet" },
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
                case "Acesso Internet":
                    await Navigation.PushAsync(new FormInternet());
                    break;
                case "Alertas":
                    await Navigation.PushAsync(new FormAlertas());
                    break;                
                default:
                    DisplayAlert("Itens", "Item não tratado!", "NOK");
                    break;
            }
        }
    }

    public class MenuConfiguracoes
    {
        public string Nome { get; set; }
    }
}