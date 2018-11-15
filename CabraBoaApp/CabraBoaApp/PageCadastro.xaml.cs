using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CabraBoaApp
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
    }

    public class MenuCadastro
    {
        public string Nome { get; set; }
    }
}