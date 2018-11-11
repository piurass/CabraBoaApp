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
	public partial class PageReproducao : ContentPage
	{
		public PageReproducao ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}