using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CabraBoaApp.forms.Cadastro;

namespace CabraBoaApp.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastro : ContentPage
	{
		public PageCadastro ()
		{
			InitializeComponent ();
            ListView.ItemsSource = new List<MenuCadastro>
            {
                new MenuCadastro { Nome = "Proprietário" },
                new MenuCadastro { Nome = "Animal" },
                new MenuCadastro { Nome = "Lote" },
                new MenuCadastro { Nome = "Crescimento" },
                new MenuCadastro { Nome = "Reprodução" }                
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as MenuCadastro;
            switch (menu.Nome)
            {
                case "Proprietário":
                    await Navigation.PushAsync(new FormProprietario());
                    break;
                default:
                    DisplayAlert("Itens", "Item Tocado não tratado!", "NOK");
                    break;
            }
        }
    }

    public class MenuCadastro
    {
        public string Nome { get; set; }
    }
}