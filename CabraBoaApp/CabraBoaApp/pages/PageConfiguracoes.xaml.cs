using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }

    public class MenuConfiguracoes
    {
        public string Nome { get; set; }
    }
}