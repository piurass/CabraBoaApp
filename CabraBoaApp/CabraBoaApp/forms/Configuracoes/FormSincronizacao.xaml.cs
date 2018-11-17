using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CabraBoaApp.dados;

namespace CabraBoaApp.forms.Configuracoes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormSincronizacao : ContentPage
	{
		public FormSincronizacao ()
		{
			InitializeComponent ();
		}

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            var Sincronizacao = new Sincronizacao
            {
                url = url.Text,
                endpoint = endpoint.Text,
                acesso = acesso.Text
            };

            DisplayAlert("Salvar", "Salvo com sucesso!", "OK");
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}